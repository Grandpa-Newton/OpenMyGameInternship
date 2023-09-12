using App.Scripts.Libs.BaseView;
using App.Scripts.Libs.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField
{
    public class ViewGridField : MonoView
    {
        [SerializeField] private Transform container;
        [SerializeField] private float cellSize;
        private IFactory<ViewGridCell> _factoryViewCell;

        private ViewGridCell[][] viewMatrix;

        public Vector2Int GridCellSize { get; private set; }
        public Vector2 CellSize { get; private set; }

        public Vector2 GridSize { get; private set; }

        public void Construct(IFactory<ViewGridCell> factoryViewCell)
        {
            _factoryViewCell = factoryViewCell;
            CellSize = new Vector2(cellSize, cellSize);
        }

        public void UpdateField(Vector2Int size)
        {
            ClearGrid();
            GridCellSize = size;
            GridSize = new Vector2(CellSize.x * size.x, CellSize.y * size.y);

            UpdateGridViews();
        }

        private void UpdateGridViews()
        {
            viewMatrix = new ViewGridCell[GridCellSize.y][];

            for (var i = 0; i < GridCellSize.y; i++)
            {
                viewMatrix[i] = new ViewGridCell[GridCellSize.x];

                for (var j = 0; j < GridCellSize.x; j++) CreateViewCell(i, j);
            }
        }

        private void CreateViewCell(int i, int j)
        {
            var view = _factoryViewCell.Create();
            view.SetupCell(i, j);
            view.UpdateSize(CellSize);
            view.SetParent(container);
            view.localScale = Vector3.one;

            view.localPosition = GetCellPosition(i, j);

            viewMatrix[i][j] = view;
        }

        public Vector2 GetCellPosition(int i, int j)
        {
            return new Vector2(j * CellSize.x + CellSize.x * 0.5f, i * CellSize.y + CellSize.y * 0.5f);
        }

        private void ClearGrid()
        {
            for (var i = 0; i < GridCellSize.y; i++)
            for (var j = 0; j < GridCellSize.x; j++)
            {
                var view = GetViewAt(i, j);
                view.Remove();
                SetViewAt(i, j, null);
            }

            GridCellSize = Vector2Int.zero;
        }

        private void SetViewAt(int i, int j, ViewGridCell cell)
        {
            if (!IsValid(i, j)) return;

            viewMatrix[i][j] = cell;
        }

        private ViewGridCell GetViewAt(int i, int j)
        {
            if (!IsValid(i, j)) return null;

            return viewMatrix[i][j];
        }

        public bool IsValid(int i, int j)
        {
            return i >= 0 && j >= 0 && i < GridCellSize.y && j < GridCellSize.x;
        }

        public bool IsValid(Vector2Int pos)
        {
            return IsValid(pos.y, pos.x);
        }

        public Vector2 GetCellPosition(Vector2Int position)
        {
            return GetCellPosition(position.y, position.x);
        }

        public Vector2Int PositionToCell(Vector3 worldPosition)
        {
            var i = (int) (worldPosition.y / CellSize.y);
            var j = (int) (worldPosition.x / CellSize.x);

            return new Vector2Int(j, i);
        }
    }
}