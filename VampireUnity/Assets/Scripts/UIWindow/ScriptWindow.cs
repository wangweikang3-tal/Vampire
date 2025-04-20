using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Wwk.Unity.UI
{

    public class ScriptWindow : UIWindow
    {
        public Action<object> OnCreateHandle;
        public Action<object> OnDestroyHandle;
        public Action<object> OnUpdateHandle;
        public Action<object> OnShowHandle;
        public Action<object> OnBeforeShowHandle;
        public Action<object> OnUpdateUIDataHandle;
        public Action<object> OnHideHandle;

        public object state;

        public override string KeyOfType { get; }

        public ScriptWindow(string key, string resName)
        {
            ResName = resName;
            KeyOfType = key ?? resName;
        }

        protected override string ResName { get; }

        protected override void OnCreate()
        {
            OnCreateHandle?.Invoke(state);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            OnDestroyHandle?.Invoke(state);

            OnCreateHandle = null;
            OnDestroyHandle = null;
            OnUpdateHandle = null;
            OnShowHandle = null;
            OnBeforeShowHandle = null;
            OnUpdateUIDataHandle = null;
            OnHideHandle = null;

        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            OnUpdateHandle?.Invoke(state);
        }

        protected override void OnShow()
        {
            base.OnShow();
            OnShowHandle?.Invoke(state);
        }

        protected override void OnBeforeShow()
        {
            base.OnBeforeShow();
            OnBeforeShowHandle?.Invoke(state);
        }

        protected override void OnUpdateUIData()
        {
            base.OnUpdateUIData();
            OnUpdateUIDataHandle?.Invoke(state);
        }

        protected override void OnHide()
        {
            base.OnHide();
            OnHideHandle?.Invoke(state);
        }

        public T FindChildBy<T>(string name) where T : Component
        {
            return this.FindChildByName<T>(name);
        }

        public T FindChildWithPath<T>(string path) where T : Component
        {
            return this.FindChildWithPath<T>(path);
        }

        public GameObject GetUIObject()
        {
            return this.UIRoot.gameObject;
        }
    }
}