using System;
using App.Scripts.Libs.BaseView;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Infrastructure.SharedViews.ItemSelector
{
    public class ButtonItemLabel : MonoViewUI
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI label;

        public event Action OnClick;

        protected override void OnAwake()
        {
            button.onClick.AddListener(() => { OnClick?.Invoke(); });
        }

        public void UpdateItem(string key)
        {
            label.text = key;
        }
    }
}