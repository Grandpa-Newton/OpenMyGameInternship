using System;
using System.Threading.Tasks;
using App.Scripts.Infrastructure.SharedViews.Animator;
using App.Scripts.Libs.TweenHelper;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.Infrastructure.LevelSelection.ViewHeader
{
    public class AnimatorHeader : BaseAnimatorTween
    {
        [SerializeField] private AnimationConfig config;
        [SerializeField] private RectTransform container;
        [SerializeField] private TextMeshProUGUI label;

        public Task AnimateChangeLabel(string value)
        {
            CancelAnimation();

            var animationChange = DOTween.Sequence();

            animationChange.Append(container.DOScale(Vector3.zero, config.durationHide).SetEase(Ease.OutCirc));
            animationChange.AppendCallback(() => { label.text = value; });

            animationChange.Append(container.DOScale(config.scaleBump, config.bumpTiming * config.durationShow)
                .SetEase(Ease.OutCirc));
            animationChange.Append(container.DOScale(Vector3.one, (1 - config.bumpTiming) * config.durationShow)
                .SetEase(Ease.OutCirc));

            return StartAnimation(animationChange).Await();
        }

        [Serializable]
        public class AnimationConfig
        {
            public float durationHide = 0.3f;
            public float scaleBump = 1.3f;

            [Range(0, 1)] public float bumpTiming = 0.8f;

            public float durationShow = 0.3f;
        }
    }
}