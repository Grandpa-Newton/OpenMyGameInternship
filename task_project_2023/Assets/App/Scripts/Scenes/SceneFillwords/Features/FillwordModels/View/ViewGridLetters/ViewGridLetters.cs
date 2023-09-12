using System.Threading.Tasks;
using App.Scripts.Libs.BaseView;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.SceneFillwords.Features.FillwordModels.View.ViewGridLetters
{
    public class ViewGridLetters : MonoViewUI
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private RectTransform container;

        [SerializeField] private AnimatorGridLetters animator;

        private IFactory<ViewLetterButton> _factoryViewLetter;

        private ViewLetterButton[][] _gridViews;

        public Vector2Int SizeCells { get; private set; }

        public void Construct(IFactory<ViewLetterButton> factoryViewLetter)
        {
            _factoryViewLetter = factoryViewLetter;
        }

        public void UpdateItems(GridFillWords gridFillWords)
        {
            Clear();

            SizeCells = gridFillWords.Size;

            UpdateViews(gridFillWords);
        }

        private void UpdateViews(GridFillWords gridFillWords)
        {
            gridLayoutGroup.cellSize = GetCellSize();

            _gridViews = new ViewLetterButton[gridFillWords.Size.y][];
            for (var i = 0; i < SizeCells.y; i++)
            {
                _gridViews[i] = new ViewLetterButton[gridFillWords.Size.x];

                for (var j = 0; j < SizeCells.x; j++)
                {
                    var view = _factoryViewLetter.Create();
                    var charModel = gridFillWords.Get(i, j);
                    view.UpdateLetter(charModel.Letter);
                    view.SetParent(container);
                    view.SetScale(Vector3.one);

                    view.RectTransform.localPosition = Vector3.zero;
                    _gridViews[i][j] = view;
                }
            }
        }

        private Vector2 GetCellSize()
        {
            var spacing = gridLayoutGroup.spacing;
            var padding = gridLayoutGroup.padding;
            var containerSize = container.rect.size;
            var width = (containerSize.x - spacing.x * (SizeCells.x - 1) - padding.horizontal) / SizeCells.x;
            var height = (containerSize.y - spacing.y * (SizeCells.y - 1) - padding.vertical) / SizeCells.y;
            return new Vector2(width, height);
        }

        private void Clear()
        {
            if (_gridViews is null) return;

            for (var i = 0; i < SizeCells.y; i++)
            for (var j = 0; j < SizeCells.x; j++)
                _gridViews[i][j].Remove();
        }

        public Task AnimateShow()
        {
            return animator.AnimateShowLetters(_gridViews);
        }

        public Task AnimateHide()
        {
            return animator.AnimateHideLetters(_gridViews);
        }
    }
}