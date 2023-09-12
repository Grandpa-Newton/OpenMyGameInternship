using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.GameCore.Models;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessSelection
{
    public class ContainerSelectedCells : ContainerUpdatable
    {
        private readonly List<Vector2Int> _selectedCells = new();

        public bool HasSelected()
        {
            return _selectedCells.Count > 0;
        }

        public IReadOnlyList<Vector2Int> SelectedCells()
        {
            return _selectedCells;
        }

        public Vector2Int GetSelectedCell()
        {
            return _selectedCells.FirstOrDefault();
        }

        public void Clear()
        {
            _selectedCells.Clear();
            NotifyUpdate();
        }

        public void SelectCell(Vector2Int clickCell)
        {
            _selectedCells.Add(clickCell);
            NotifyUpdate();
        }
    }
}