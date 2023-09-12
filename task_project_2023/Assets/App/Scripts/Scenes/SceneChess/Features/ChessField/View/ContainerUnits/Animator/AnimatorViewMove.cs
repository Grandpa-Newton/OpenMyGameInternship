using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.SharedViews.Animator;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits.Animator
{
    public class AnimatorViewMove : BaseAnimatorTween
    {
        [SerializeField] private Transform container;

        [SerializeField] private AnimatorConfig config;

        public void AnimatePath(List<Vector3> animationPath)
        {
            CancelAnimation();

            var animationMove = DOTween.Sequence();

            foreach (var point in animationPath)
                animationMove.Append(container.DOLocalMove(point, config.durationMove).SetEase(Ease.InSine));

            StartAnimation(animationMove);
        }

        [Serializable]
        public class AnimatorConfig
        {
            public float durationMove;
        }
    }
}