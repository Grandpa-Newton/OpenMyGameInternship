using App.Scripts.Libs.BaseView;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField
{
    public class ViewGridCell : MonoView
    {
        [SerializeField] private SpriteRenderer spriteCellRenderer;

        [SerializeField] private Color colorOdd;
        [SerializeField] private Color colorEven;

        public void SetupCell(int i, int j)
        {
            UpdateColorByIndex(i, j);
        }

        private void UpdateColorByIndex(int i, int j)
        {
            var colorValue = (i + j % 2) % 2 == 0;
            spriteCellRenderer.color = colorValue ? colorOdd : colorEven;
        }

        public void UpdateSize(Vector2 cellSize)
        {
            spriteCellRenderer.size = cellSize;
        }
    }
}