using System.Collections.Generic;
using UnityEngine;

public class BagController : XSingleton<BagController>
{
    public List<EquipBase> equipList = new List<EquipBase>();

    public void EquipToMySql()
    {
        foreach (var equip in equipList)
        {
            
        }
    }
}
