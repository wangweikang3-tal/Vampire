using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : XSingleton<BagController>
{
    public Dictionary<int, Sprite> EquipidDic = new Dictionary<int, Sprite>();
    public GameObject bagGrid;

    protected override void Awake()
    {
        bagGrid = Resources.Load("Prefabs/Equip/BagGrid")as GameObject;
    }

    public void ShowEquip()
    {
        foreach (var equip in EquipidDic)
        {
            bagGrid.transform.Find("BagGridImage").GetComponent<Image>().sprite = equip.Value;
            Instantiate(bagGrid, UITool.S.GetChildGameObject("EquipContent").transform);
        }
    }

    public void AddEquip(EquipBase equip)
    {
        var equiptemp=new EquipBase(equip.equipName,equip.EquipAttributes);
    }
}
