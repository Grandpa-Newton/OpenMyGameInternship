using System.Collections.Generic;
using App.Scripts.Libs.BaseView;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord
{
    public class ViewWord : MonoViewUI
    {
        [SerializeField] private RectTransform containerLetters;
        [SerializeField] private CanvasGroup canvasGroup;

        private readonly List<ViewLetterButton> _viewsLetters = new();
        private IFactory<ViewLetterButton, char> _factoryButtons;
        private string _word;
        public CanvasGroup CanvasGroup => canvasGroup;

        public void Construct(IFactory<ViewLetterButton, char> factoryButtons)
        {
            _factoryButtons = factoryButtons;
        }

        public void UpdateItem(string word)
        {
            _word = word;
            ClearViewLetters();

            UpdateLetters();
        }

        private void UpdateLetters()
        {
            foreach (var c in _word)
            {
                var viewLetter = _factoryButtons.Create(c);
                viewLetter.SetParent(containerLetters);
                viewLetter.SetScale(Vector3.one);
                _viewsLetters.Add(viewLetter);
            }
        }

        private void ClearViewLetters()
        {
            foreach (var view in _viewsLetters) view.Remove();

            _viewsLetters.Clear();
        }
    }
}