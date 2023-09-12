using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Infrastructure.LevelSelection.ViewHeader
{
    public class ViewLevelHeader : MonoBehaviour, IDisposable
    {
        [SerializeField] private Button buttonNext;
        [SerializeField] private Button buttonPrev;

        [SerializeField] private AnimatorHeader animator;

        private void Awake()
        {
            buttonNext.onClick.AddListener(() => { OnNextLevel?.Invoke(); });

            buttonPrev.onClick.AddListener(() => { OnPrevLevel?.Invoke(); });
        }

        public event Action OnNextLevel;
        public event Action OnPrevLevel;

        public Task UpdateLevelLabelAnimate(string levelInfo)
        {
            return animator.AnimateChangeLabel(levelInfo);
        }

        public void Cleanup()
        {
            OnNextLevel = null;
            OnPrevLevel = null;
        }

        public void Dispose()
        {
            animator.CancelAnimation();
        }
    }
}