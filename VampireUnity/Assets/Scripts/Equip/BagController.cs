using System.Collections.Generic;
using UnityEngine;

public class BagController : XSingleton<BagController>
{
    public List<EquipBase> equipList = new List<EquipBase>();
    public GameObject bagGrid;

    protected override void Awake()
    {
        bagGrid = Resources.Load("Prefabs/Equip/BagGrid")as GameObject;
    }

    public void ShowEquip()
    {
        foreach (var equip in equipList)
        {
            Instantiate(bagGrid, UITool.S.GetChildGameObject("EquipContent").transform);
        }
    }
}
