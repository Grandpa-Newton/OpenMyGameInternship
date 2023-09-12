using System;
using System.Collections.Generic;
using App.Scripts.Libs.Factory;
using UnityEngine;

namespace App.Scripts.Infrastructure.SharedViews.ItemSelector
{
    public class ViewItemSelector<T> : MonoBehaviour, IViewItemSelector<T>
    {
        [SerializeField] private RectTransform container;

        private readonly List<ButtonItemLabel> _items = new();
        private IFactory<ButtonItemLabel> _factoryButtons;

        public event Action<T> OnItemSelected;

        public void UpdateItems(IEnumerable<T> items)
        {
            Clear();
            CreateItems(items);
        }

        public void Clear()
        {
            foreach (var itemLabel in _items) itemLabel.Remove();

            _items.Clear();
        }

        public void Construct(IFactory<ButtonItemLabel> factory)
        {
            _factoryButtons = factory;
        }

        private void CreateItems(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var view = _factoryButtons.Create();
                view.UpdateItem(item.ToString());
                view.SetParent(container);
                view.SetScale(Vector3.one);
                view.RectTransform.localPosition = Vector3.zero;

                view.OnClick += () => { OnItemClicked(item); };
            }
        }

        private void OnItemClicked(T item)
        {
            OnItemSelected?.Invoke(item);
        }
    }
}