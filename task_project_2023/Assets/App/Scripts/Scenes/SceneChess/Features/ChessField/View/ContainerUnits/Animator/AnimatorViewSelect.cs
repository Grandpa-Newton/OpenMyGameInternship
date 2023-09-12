using System;
using App.Scripts.Infrastructure.SharedViews.Animator;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits.Animator
{
    public class AnimatorViewSelect : BaseAnimatorTween
    {
        [SerializeField] private Transform container;

        [SerializeField] private AnimatorConfig config;

        public void AnimateUnselect()
        {
            CancelAnimation();

            var animationSelect = DOTween.Sequence();
            animationSelect.Append(container.DOScale(Vector3.one, config.durationSelect).SetEase(Ease.OutSine));

            StartAnimation(animationSelect);
        }

        public void AnimateSelect()
        {
            var animationSelect = DOTween.Sequence();
            animationSelect.Append(container.DOScale(config.selectScale, config.durationSelect).SetEase(Ease.OutCirc));

            StartAnimation(animationSelect);
        }

        [Serializable]
        public class AnimatorConfig
        {
            public float selectScale = 1.2f;
            public float durationSelect = 0.3f;
        }
    }
}