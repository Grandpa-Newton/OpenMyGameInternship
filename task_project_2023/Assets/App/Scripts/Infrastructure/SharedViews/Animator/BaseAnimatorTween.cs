using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Infrastructure.SharedViews.Animator
{
    public class BaseAnimatorTween : MonoBehaviour
    {
        protected Sequence _animation;
        public bool IsAnimating => _animation != null;

        protected Sequence StartAnimation(Sequence tween)
        {
            _animation = tween;
            tween.AppendCallback(() => { _animation = null; });
            return tween;
        }

        public void CancelAnimation()
        {
            if (_animation is null) return;

            _animation.Kill(true);
            _animation = null;
        }
    }
}