using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Libs.TweenHelper;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord.Animator
{
    public class AnimatorFieldWord : AnimatorFieldWordBase
    {
        [SerializeField] private AnimationConfig config;

        public override Task AnimateAppearAsync(List<ViewWord> viewWords)
        {
            CancelAnimation();

            var sequence = DOTween.Sequence();

            float offset = 0;
            foreach (var viewWord in viewWords)
            {
                sequence.Insert(offset, AnimateShowWord(viewWord));
                offset += config.delayAnimationWord;
            }

            return StartAnimation(sequence).Await();
        }

        private Tween AnimateShowWord(ViewWord viewWord)
        {
            var sequence = DOTween.Sequence();

            viewWord.CanvasGroup.alpha = 0;
            viewWord.RectTransform.localScale = Vector3.zero;
            sequence.Append(viewWord.RectTransform.DOScale(config.bumpScale, config.durationBump * config.delayShow)
                .SetEase(Ease.OutCirc));

            sequence.Append(viewWord.RectTransform.DOScale(Vector3.one, (1 - config.durationBump) * config.delayShow)
                .SetEase(Ease.OutCirc));

            sequence.Insert(0, viewWord.CanvasGroup.DOFade(1, config.delayShow).SetEase(Ease.InSine));

            return sequence;
        }

        public override Task AnimateHideAsync(List<ViewWord> viewWords)
        {
            CancelAnimation();

            var sequence = DOTween.Sequence();

            float offset = 0;
            foreach (var viewWord in viewWords)
            {
                sequence.Insert(offset, AnimateHideWord(viewWord));
                offset += config.delayAnimationWord;
            }

            return StartAnimation(sequence).Await();
        }

        private Tween AnimateHideWord(ViewWord viewWord)
        {
            var sequence = DOTween.Sequence();

            sequence.Append(viewWord.RectTransform.DOScale(Vector3.zero, config.durationHideWord)
                .SetEase(Ease.OutCirc));

            sequence.Insert(0, viewWord.CanvasGroup.DOFade(0, config.durationHideWord * 0.5f).SetEase(Ease.InSine));

            return sequence;
        }

        [Serializable]
        private class AnimationConfig
        {
            public float delayShow = 0.3f;
            public float bumpScale = 1.3f;

            [Range(0, 1)] public float durationBump = 0.7f;

            public float delayAnimationWord = 0.1f;
            public float durationHideWord = 0.5f;
        }
    }
}