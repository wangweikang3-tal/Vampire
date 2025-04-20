using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Com.Wwk.Unity.UI;
using UnityEngine;
using Object = UnityEngine.Object;



    public interface IWindowResourceLoader
    {
        GameObject GetInstanceWindow();
        UIWindow Window { get; }
        void Destroy(GameObject go);
    }
    

    public class UIResourcesAttribute : Attribute
    {
        //构造函数
        public UIResourcesAttribute(string name)
        {
            Name = name;
        }

        public string Name { private set; get; }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum WindowState
    {
        NONE,
        ONSHOWING,
        SHOW,
        ONHIDING,
        HIDDEN
    }

    public abstract class UIWindow : UIElement
    {
        private IWindowResourceLoader _loader;
        protected virtual string ResName =>
            this.GetType().GetCustomAttributes(typeof(UIResourcesAttribute), false)
                is UIResourcesAttribute[] {Length: > 0} attrs ? attrs[0].Name : string.Empty;

        public override string KeyOfType => ResName;
        
        private MonoBehaviour _runner;

        protected UIWindow()
        {
            CanDestroyWhenHidden = false;
        }

        public void StartCoroutine(IEnumerator el)
        {
            _runner.StartCoroutine(el);
        }
        
        public void StopAllCoroutines()
        {
            _runner.StopAllCoroutines();
        }

        protected override void OnDestroy()
        {
            _loader?.Destroy(UIRoot);
            if (UIRoot) UIRoot = null;
        }


        protected virtual void OnUpdateUIData()
        {
        }

        protected virtual void OnShow()
        {
           
        }

        protected virtual void OnHide()
        {
           
        }

        protected virtual void OnUpdate()
        {

        }

        protected virtual void OnBeforeShow()
        {

        }

        protected virtual void OnLanguage() { }

        private bool _asLastSibling = false;
        public void ShowWindow(bool asLastSibling = true)
        {
            _asLastSibling = asLastSibling;
            this._state = WindowState.ONSHOWING;
        }
        

        public void HideWindow(bool forceDestroy = false)
        {
            this._state = WindowState.ONHIDING;
            if (forceDestroy) CanDestroyWhenHidden = true;
        }

        private void Update()
        {
            switch (_state)
            {
                case WindowState.NONE:
                    break;
                case WindowState.ONSHOWING:
                    this.UIRoot.SetActive(true);
                    if(_asLastSibling) Rect.SetAsLastSibling();
                    OnBeforeShow(); 
                    _state = WindowState.SHOW; 
                   
                    OnShow();
                    break;
                case WindowState.SHOW:
                    OnUpdate();
                    break;
                case WindowState.ONHIDING:
                    _state = WindowState.HIDDEN;
                    OnHide();
                    this.UIRoot.SetActive(false);
                    break;
                case WindowState.HIDDEN:

                    break;
            }
        }

        protected bool CanDestroyWhenHidden { set; get; }

        public bool IsVisible {
            get
            {
                return _state switch
                {
                    WindowState.NONE => false,
                    WindowState.HIDDEN => false,
                    _ => true
                };
            }
        }


        public bool IsShowIng => _state == WindowState.ONSHOWING;

        public bool CanDestroy => _state == WindowState.HIDDEN && CanDestroyWhenHidden;
        

        public static void UpdateUI(UIWindow w)
        {
            w.Update();
        }

        public static void UpdateUIData(UIWindow w)
        {
            if (w._state == WindowState.SHOW)
                w.OnUpdateUIData();
        }

        private WindowState _state = WindowState.NONE;
        
        
        public static async Task<T> CreateAsync<T>(T window = null, Transform uiRoot =null,IWindowResourceLoader loader =null) where T : UIWindow ,new()
        {
            loader ??= DefaultOpenUIAsync<T>.Create(window: window);
            window = loader.Window as T;
            if(window == null)  throw new Exception("No found Window!");
            var name = loader.Window.ResName;
            if (string.IsNullOrEmpty(name)) throw new Exception("No found UIResourcesAttribute!");
            var res = await loader.GetInstanceWindow();
            window.UIRoot = res;
            if(uiRoot)  window.Rect.SetParent(uiRoot, false);
            window.UIRoot.name = $"UI_{name}";
            window._runner = res.AddComponent<TalBehaviourScript>();
            window._loader = loader;
            window.OnCreate();
            return window;

        }

    }

    public class DefaultOpenUIAsync<T> : IWindowResourceLoader where T : UIWindow, new()
    {
        private DefaultOpenUIAsync(T window)
        {
            Window = window;
        }

        public async Task<GameObject> GetInstanceWindow()
        {
            var resource =
                typeof(T).GetCustomAttributes<UIResourcesAttribute>(false).FirstOrDefault();
            if (resource == null) throw new Exception("No attribute");
            var request = Resources.LoadAsync<GameObject>($"Windows/{resource.Name}");
            await request;
            var go = Object.Instantiate(request.asset as GameObject);
            go.name = request.asset.name;
            return go;
        }

        public UIWindow Window { get; }

        public void Destroy(GameObject go)
        {
            Object.Destroy(go);
        }

        public static IWindowResourceLoader Create(T window = null)
        {
            window ??= new T();
            return new DefaultOpenUIAsync<T>(window);
        }
    }