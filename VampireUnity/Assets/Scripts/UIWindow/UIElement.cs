using UnityEngine;

namespace Com.Wwk.Unity.UI
{
    public abstract class UIElement
    {
        protected GameObject UIRoot;
        protected abstract void OnDestroy();
        protected abstract void OnCreate();
        protected RectTransform _rect;

        public virtual string KeyOfType { get; }

        protected RectTransform Rect
        {
            get
            {
                if (_rect)
                    return _rect;
                else
                {
                    _rect = this.UIRoot.GetComponent<RectTransform>();
                    return _rect;
                }
            }
        }

        public static void Destroy(UIElement el)
        {
            el.OnDestroy();
        }

        protected T FindChildByName<T>(string name) where T : Component
        {
            return UIRoot.transform.FindChild<T>(name);
        }

        protected T FindByPath<T>(string path) where T : Component
        {
            return UIRoot.transform.Find<T>(path);
        }

        protected UIElement() => this.KeyOfType = this.GetType().Name;
    }
}
