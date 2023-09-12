using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput.Animator;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput
{
    public class ViewCharSelector : MonoBehaviour, IViewCharSelector, IDisposable
    {
        [SerializeField] private AnimatorViewCharSelectorBase animator;

        [SerializeField] private RectTransform containerButtons;

        [SerializeField] private float InitialPlaceAngleDeg = 90f;

        [SerializeField] private float RadiusHeightPercent = 0.5f;

        [SerializeField] [Range(0, 1)] private float ItemSizePercent = 0.2f;

        private readonly List<ViewLetterButton> buttons = new();
        private IFactory<ViewLetterButton, char> _factory;
        private Vector2 _itemSize;

        public void SetupChars(IEnumerable<char> chars)
        {
            Clear();
            UpdateItemSize();

            foreach (var c in chars)
            {
                var viewLetter = _factory.Create(c);
                viewLetter.SetParent(containerButtons);
                viewLetter.RectTransform.localScale = Vector3.one;
                viewLetter.SetupSize(_itemSize);
                buttons.Add(viewLetter);
            }

            UpdateButtonsPosition();
        }

        public void Clear()
        {
            foreach (var viewLetterButton in buttons) viewLetterButton.Remove();

            buttons.Clear();
        }

        public Task AnimateAppearAsync()
        {
            return animator.AnimateAppearAsync(buttons);
        }

        public Task AnimateHideAsync()
        {
            return animator.AnimateHideAsync(buttons);
        }

        public void Construct(IFactory<ViewLetterButton, char> factory)
        {
            _factory = factory;
        }

        private void UpdateItemSize()
        {
            var size = containerButtons.rect.size;
            var itemSize = size.y * ItemSizePercent;
            _itemSize = new Vector2(itemSize, itemSize);
        }

        private void UpdateButtonsPosition()
        {
            var countButtons = buttons.Count;
            var buttonSectorAngle = Mathf.PI * 2f / countButtons;

            var angle = Mathf.Deg2Rad * InitialPlaceAngleDeg;
            var radiusPlace = containerButtons.rect.size.y * RadiusHeightPercent;

            foreach (var viewLetterButton in buttons)
            {
                var buttonPosition = new Vector2(radiusPlace * Mathf.Cos(angle), radiusPlace * Mathf.Sin(angle));
                viewLetterButton.RectTransform.anchoredPosition = buttonPosition;
                angle += buttonSectorAngle;
            }
        }

        public void Dispose()
        {
            animator.CancelAnimation();
        }
    }
}