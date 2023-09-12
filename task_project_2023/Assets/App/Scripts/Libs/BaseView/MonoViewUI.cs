using UnityEngine;

namespace App.Scripts.Libs.BaseView
{
    public class MonoViewUI : MonoBehaviour
    {
        [SerializeField] private RectTransform root;

        public RectTransform RectTransform => root;

        private void Awake()
        {
            if (root is null) root = GetComponent<RectTransform>();

            OnAwake();
        }

        public void SetScale(Vector3 scaleValue)
        {
            RectTransform.localScale = scaleValue;
        }

        protected virtual void OnAwake()
        {
        }

        public virtual void Remove()
        {
            Cleanup();
            Destroy(gameObject);
        }

        public virtual void Cleanup()
        {
        }

        public virtual void SetParent(RectTransform containerButtons)
        {
            root.SetParent(containerButtons);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}