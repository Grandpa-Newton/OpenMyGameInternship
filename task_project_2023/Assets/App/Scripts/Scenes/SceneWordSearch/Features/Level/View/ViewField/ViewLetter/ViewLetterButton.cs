using System;
using App.Scripts.Libs.BaseView;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter
{
    public class ViewLetterButton : MonoViewUI, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI label;

        public char LetterChar { get; private set; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnterView?.Invoke(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExitView?.Invoke(this);
        }

        public event Action<ViewLetterButton> OnEnterView;
        public event Action<ViewLetterButton> OnExitView;

        public void UpdateLetter(char letterChar)
        {
            LetterChar = letterChar;
            label.text = letterChar.ToString();
        }

        public override void Cleanup()
        {
            OnEnterView = null;
            OnExitView = null;
        }

        public void SetupSize(Vector2 itemSize)
        {
            RectTransform.sizeDelta = itemSize;
        }
    }
}