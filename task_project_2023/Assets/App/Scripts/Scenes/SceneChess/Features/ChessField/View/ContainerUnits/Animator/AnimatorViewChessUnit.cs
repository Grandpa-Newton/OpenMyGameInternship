using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.SharedViews.Animator;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits.Animator
{
    public class AnimatorViewChessUnit : MonoBehaviour
    {
        [SerializeField] private AnimatorViewMove _animatorViewMove;
        [SerializeField] private AnimatorViewSelect _animatorViewSelect;

        private readonly List<BaseAnimatorTween> _animators = new();

        public bool IsAnimating => IsSomeAnimation();

        private void Awake()
        {
            _animators.Add(_animatorViewMove);
            _animators.Add(_animatorViewSelect);
        }

        private bool IsSomeAnimation()
        {
            return _animators.Any(x => x.IsAnimating);
        }

        public void AnimateUnselect()
        {
            _animatorViewSelect.AnimateUnselect();
        }

        public void AnimateSelect()
        {
            _animatorViewSelect.AnimateSelect();
        }

        public void AnimatePath(List<Vector3> movePath)
        {
            _animatorViewMove.AnimatePath(movePath);
        }
    }
}