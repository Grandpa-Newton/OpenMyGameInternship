using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Container;
using App.Scripts.Scenes.SceneChess.Features.ChessSelection;
using App.Scripts.Scenes.SceneChess.Features.GridInput;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Systems
{
    public class SystemProcessCellClick : ISystem
    {
        private readonly ContainerChessLevel _containerChessLevel;
        private readonly ContainerFieldInput _containerFieldInput;
        private readonly ContainerPieceMoves _containerPieceMoves;
        private readonly ContainerSelectedCells _containerSelectedCells;

        public SystemProcessCellClick(ContainerFieldInput containerFieldInput,
            ContainerSelectedCells containerSelectedCells, ContainerChessLevel containerChessLevel,
            ContainerPieceMoves containerPieceMoves)
        {
            _containerFieldInput = containerFieldInput;
            _containerSelectedCells = containerSelectedCells;
            _containerChessLevel = containerChessLevel;
            _containerPieceMoves = containerPieceMoves;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (!_containerFieldInput.IsUpdated) return;

            var clickCell = _containerFieldInput.ClickCell;

            if (_containerSelectedCells.HasSelected())
            {
                ProcessSelectedCell(clickCell);
                return;
            }

            ProcessSelectCell(clickCell);
        }

        public void Cleanup()
        {
        }

        private void ProcessSelectedCell(Vector2Int clickCell)
        {
            var selectedCell = _containerSelectedCells.GetSelectedCell();

            if (selectedCell == clickCell)
            {
                ClearSelection();
                return;
            }

            ProcessMove(selectedCell, clickCell);
        }

        private void ClearSelection()
        {
            _containerSelectedCells.Clear();
        }

        private void ProcessMove(Vector2Int selectedCell, Vector2Int clickCell)
        {
            var chessGrid = _containerChessLevel.Grid;
            var pieceFrom = chessGrid.Get(selectedCell);

            if (pieceFrom is null)
            {
                ClearSelection();
                return;
            }

            var pieceTo = chessGrid.Get(clickCell);
            if (pieceTo != null) return;

            _containerPieceMoves.AddMove(selectedCell, clickCell);
        }

        private void ProcessSelectCell(Vector2Int clickCell)
        {
            var chessGrid = _containerChessLevel.Grid;
            var pieceFrom = chessGrid.Get(clickCell);

            if (pieceFrom is null || pieceFrom.IsAvailable) return;

            _containerSelectedCells.SelectCell(clickCell);
        }
    }
}