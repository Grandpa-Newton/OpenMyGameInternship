using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Libs.TweenHelper;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput.Animator
{
    public class AnimatorViewCharSelector : AnimatorViewCharSelectorBase
    {
        [SerializeField] private AnimationConfig config;

        public override Task AnimateAppearAsync(List<ViewLetterButton> viewLetterButtons)
        {
            CancelAnimation();

            var animSequence = DOTween.Sequence();

            foreach (var viewLetterButton in viewLetterButtons)
                animSequence.Join(AnimateButtonAppear(viewLetterButton));

            return StartAnimation(animSequence).Await();
        }

        private Tween AnimateButtonAppear(ViewLetterButton viewLetterButton)
        {
            var sequence = DOTween.Sequence();

            var placePosition = viewLetterButton.RectTransform.anchoredPosition;

            var scale = viewLetterButton.RectTransform.localScale;
            viewLetterButton.RectTransform.localScale = Vector3.zero;
            viewLetterButton.RectTransform.anchoredPosition = Vector2.zero;

            sequence.Append(viewLetterButton.RectTransform
                .DOScale(config.bumpScale, config.delayShow * 0.7f).SetEase(Ease.OutCirc));

            sequence.Append(viewLetterButton.RectTransform
                .DOScale(scale, config.delayShow * 0.3f).SetEase(Ease.OutCirc));

            sequence.Insert(0,
                viewLetterButton.RectTransform.DOAnchorPos(placePosition, config.delayShow).SetEase(Ease.OutBounce));

            return sequence;
        }

        public override Task AnimateHideAsync(List<ViewLetterButton> viewLetterButtons)
        {
            CancelAnimation();

            var animSequence = DOTween.Sequence();

            foreach (var viewLetterButton in viewLetterButtons) animSequence.Join(AnimateButtonHide(viewLetterButton));

            return StartAnimation(animSequence).Await();
        }

        private Tween AnimateButtonHide(ViewLetterButton viewLetterButton)
        {
            var sequence = DOTween.Sequence();

            sequence.Append(
                viewLetterButton.RectTransform.DOAnchorPos(Vector2.zero, config.delayHide).SetEase(Ease.OutSine));

            sequence.Insert(config.delayHide * 0.6f, viewLetterButton.RectTransform
                .DOScale(new Vector3(0, 0, 0), config.delayHide * 0.7f).SetEase(Ease.OutSine));

            return sequence;
        }

        [Serializable]
        public class AnimationConfig
        {
            public float delayShow = 0.3f;
            public float delayHide = 0.3f;
            public float bumpScale = 1.3f;
        }
    }
}