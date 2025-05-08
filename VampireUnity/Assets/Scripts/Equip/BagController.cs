using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BagController : XSingleton<BagController>
{
    [NonSerialized]public Dictionary<int, Sprite> EquipidDic = new Dictionary<int, Sprite>();
    [NonSerialized]public GameObject bagGrid;
    [NonSerialized]public GameObject bag;


    protected override void Awake()
    {
        bag=Instantiate(Resources.Load("Prefabs/Window/Bag"),GameObject.Find("UIRoot").transform).GameObject();
        bag.gameObject.SetActive(false);
        bagGrid = Resources.Load("Prefabs/Equip/BagGrid")as GameObject;
    }

    public void ShowEquip()
    {
        GameObject equipContent = UITool.S.GetChildGameObject("EquipContent");
        //清空equipContent的所有子物体
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var equip in EquipidDic)
        {
            bagGrid.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = equip.Value;
            GameObject bagGridins=Instantiate(bagGrid, equipContent.transform);
            bagGridins.GetComponent<BagGrid>().EquipId = equip.Key;
            bagGridins.GetComponent<BagGrid>().equipAttributeImage=equip.Value;
        }
    }

    public void ShowBag()
    {
        //暂停游戏
        Time.timeScale = 0;
        bag.gameObject.SetActive(true);
        ShowEquip();
    }

    public void HideBag()
    {
        //暂停游戏
        Time.timeScale = 1;
        bag.gameObject.SetActive(false);
    }
    

    public void AddEquip(EquipBase equip)
    {
        var equiptemp=new EquipBase(equip.equipName,equip.EquipAttributes);
    }
}
