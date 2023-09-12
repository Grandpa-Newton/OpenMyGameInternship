using System;
using System.Threading.Tasks;
using App.Scripts.Infrastructure.SharedViews.Animator;
using App.Scripts.Libs.TweenHelper;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.FillwordModels.View.ViewGridLetters
{
    public class AnimatorGridLetters : BaseAnimatorTween
    {
        [SerializeField] private AnimationConfig config;

        public Task AnimateShowLetters(ViewLetterButton[][] gridViews)
        {
            var anim = DOTween.Sequence();

            var height = gridViews.Length;
            var width = gridViews[0].Length;

            var perLetterDelay = config.durationShow / (height * width);
            float offset = 0;
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
            {
                var view = gridViews[i][j];
                anim.Insert(offset, AnimateShowLetter(view));
                offset += perLetterDelay;
            }

            return StartAnimation(anim).Await();
        }

        private Tween AnimateShowLetter(ViewLetterButton view)
        {
            var anim = DOTween.Sequence();

            view.RectTransform.localScale = Vector3.zero;
            anim.Append(
                view.RectTransform.DOScale(config.bumpScale, config.bumpValue * config.durationShowLetter)
                    .SetEase(Ease.OutCubic));
            anim.Append(
                view.RectTransform.DOScale(Vector3.one, config.bumpValue * config.durationShowLetter)
                    .SetEase(Ease.OutCubic));
            return anim;
        }

        public Task AnimateHideLetters(ViewLetterButton[][] gridViews)
        {
            var anim = DOTween.Sequence();

            float offset = 0;
            var perRowDelay = config.durationHide / gridViews.Length;

            for (var i = 0; i < gridViews.Length; i++)
            {
                for (var j = 0; j < gridViews[i].Length; j++)
                {
                    var view = gridViews[i][j];
                    anim.Insert(offset, AnimateHideLetter(view));
                }

                offset += perRowDelay;
            }

            return StartAnimation(anim).Await();
        }

        private Tween AnimateHideLetter(ViewLetterButton view)
        {
            var anim = DOTween.Sequence();

            anim.Append(
                view.RectTransform.DOScale(Vector3.zero, config.durationHideLetter)
                    .SetEase(Ease.OutSine));

            return anim;
        }

        [Serializable]
        public class AnimationConfig
        {
            public float bumpScale = 1.3f;

            [Range(0, 1)] public float bumpValue = 0.7f;

            public float durationShowLetter = 0.3f;
            public float durationHideLetter = 0.3f;
            public float durationShow = 1f;
            public float durationHide = 0.8f;
        }
    }
}