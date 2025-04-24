using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager:XSingleton<UIManager>
{
    private Dictionary<UIType, GameObject> uiDic;
    public UIManager()
    {
        uiDic = new Dictionary<UIType, GameObject>();
    }

    public GameObject GetUIWindow(UIType uiType)
    {
        GameObject UIRoot= GameObject.Find("UIRoot");
        if (UIRoot == null)
        {
            Debug.LogError("UIRoot为空!");
            return null;
        }
        if (uiDic.ContainsKey(uiType))
        {
            GameObject ui = uiDic[uiType];
            ui.SetActive(true);
            return ui;
        }
        //创建UI实例，并且设置UIRoot为父类
        GameObject uiPrefab = GameObject.Instantiate(Resources.Load<GameObject>(uiType.path),UIRoot.transform);
        if (uiPrefab == null)
        {
            Debug.LogError($"没有找到UI:{uiType.name}");
            return null;
        }
        uiPrefab.name = uiType.name;
        uiDic.Add(uiType,uiPrefab);
        return uiPrefab;
    }

    public void DestroyUIWindow(UIType uiType)
    {
        if (uiDic.ContainsKey(uiType))
        {
            Destroy(uiDic[uiType]);
            uiDic.Remove(uiType);
        }
    }
    
}