using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Infrastructure.SharedViews.Animator;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput.Animator
{
    public abstract class AnimatorViewCharSelectorBase : BaseAnimatorTween
    {
        public abstract Task AnimateAppearAsync(List<ViewLetterButton> viewLetterButtons);
        public abstract Task AnimateHideAsync(List<ViewLetterButton> viewLetterButtons);
    }
}