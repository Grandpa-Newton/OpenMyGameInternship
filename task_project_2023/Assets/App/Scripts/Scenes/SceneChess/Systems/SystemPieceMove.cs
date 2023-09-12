using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Container;
using App.Scripts.Scenes.SceneChess.Features.ChessSelection;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator;

namespace App.Scripts.Scenes.SceneChess.Systems
{
    public class SystemPieceMove : ISystem
    {
        private readonly IChessGridNavigator _chessGridNavigator;
        private readonly ContainerChessLevel _containerChessLevel;
        private readonly ContainerPieceMoves _containerPieceMoves;
        private readonly ContainerSelectedCells _containerSelectedCells;

        public SystemPieceMove(ContainerPieceMoves containerPieceMoves,
            IChessGridNavigator chessGridNavigator, ContainerChessLevel containerChessLevel,
            ContainerSelectedCells containerSelectedCells)
        {
            _containerPieceMoves = containerPieceMoves;
            _chessGridNavigator = chessGridNavigator;
            _containerChessLevel = containerChessLevel;
            _containerSelectedCells = containerSelectedCells;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (!_containerPieceMoves.HasMoves()) return;

            foreach (var move in _containerPieceMoves.Moves) ProcessMove(move);
        }

        public void Cleanup()
        {
        }

        private void ProcessMove(MoveRequest move)
        {
            var grid = _containerChessLevel.Grid;
            var piece = grid.Get(move.From);
            var pathCells = _chessGridNavigator.FindPath(piece.PieceModel.PieceType, move.From, move.To, grid);
            if (pathCells is null) return;

            move.Path = pathCells;
            move.ChessUnit = piece;
            grid.Move(move.From, move.To);

            ClearSelection();
        }

        private void ClearSelection()
        {
            _containerSelectedCells.Clear();
        }
    }
}