using System.Collections.Generic;
using System.Linq;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Container;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits;
using App.Scripts.Scenes.SceneChess.Features.ChessSelection;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Systems
{
    public class SystemProcessViewSelect : ISystem
    {
        private readonly List<Vector2Int> _buffer = new();
        private readonly ContainerChessLevel _containerChessLevel;
        private readonly ContainerSelectedCells _containerSelectedCells;

        private readonly Dictionary<Vector2Int, ViewChessUnit> _selectedViews = new();

        public SystemProcessViewSelect(ContainerSelectedCells containerSelectedCells,
            ContainerChessLevel containerChessLevel)
        {
            _containerSelectedCells = containerSelectedCells;
            _containerChessLevel = containerChessLevel;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (!_containerSelectedCells.HasSelected())
            {
                ClearViewSelection();
                return;
            }

            UpdateSelection(_containerSelectedCells.SelectedCells());
        }

        public void Cleanup()
        {
            _selectedViews.Clear();
        }

        private void UpdateSelection(IReadOnlyList<Vector2Int> selectedCells)
        {
            _buffer.Clear();

            foreach (var keyValueSelected in _selectedViews)
                if (!selectedCells.Contains(keyValueSelected.Key))
                {
                    keyValueSelected.Value.AnimateUnselect();
                    _buffer.Add(keyValueSelected.Key);
                }

            foreach (var cellRemove in _buffer) _selectedViews.Remove(cellRemove);

            foreach (var selectedCell in selectedCells)
                if (!_selectedViews.ContainsKey(selectedCell))
                {
                    var view = GetCellView(selectedCell);
                    view.AnimateSelect();
                    _selectedViews[selectedCell] = view;
                }
        }

        private ViewChessUnit GetCellView(Vector2Int selectedCell)
        {
            var grid = _containerChessLevel.Grid;
            var piece = grid.Get(selectedCell);
            return piece?.View;
        }

        private void ClearViewSelection()
        {
            foreach (var viewChessUnit in _selectedViews) viewChessUnit.Value.AnimateUnselect();

            _selectedViews.Clear();
        }
    }
}