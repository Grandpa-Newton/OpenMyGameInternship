using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord.Animator;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord
{
    public class ViewFieldWords : MonoBehaviour, IDisposable
    {
        [SerializeField] private RectTransform containerWords;
        [SerializeField] private AnimatorFieldWordBase animator;

        private readonly List<ViewWord> _viewWords = new();
        private IFactory<ViewWord> _factoryViewWord;

        public void Construct(IFactory<ViewWord> factoryViewWord)
        {
            _factoryViewWord = factoryViewWord;
        }

        public void UpdateWords(IEnumerable<string> words)
        {
            Clear();

            CreateWordViews(words);
        }

        private void CreateWordViews(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                var view = _factoryViewWord.Create();
                view.UpdateItem(word);
                view.SetParent(containerWords);
                view.SetScale(Vector3.one);
                _viewWords.Add(view);
            }

            RelayoutViews();
        }

        private void RelayoutViews()
        {
        }

        public void Clear()
        {
            foreach (var viewWord in _viewWords) viewWord.Remove();

            _viewWords.Clear();
        }

        public Task AnimateAppearAsync()
        {
            return animator.AnimateAppearAsync(_viewWords);
        }

        public Task AnimateHideAsync()
        {
            return animator.AnimateHideAsync(_viewWords);
        }

        public void Dispose()
        {
            animator.CancelAnimation();
        }
    }
}