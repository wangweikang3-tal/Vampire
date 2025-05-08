using System;
using Mysql;
using Tool;
using UnityEngine;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour
{
    [NonSerialized]public int EquipId;
    public Button gridButton;
    [NonSerialized]public Sprite equipAttributeImage;



    private void Awake()
    {
        gridButton.onClick.AddListener(() =>
        {
            EquipTable equipTable = EquipController.S.GetEquipAttributeFromMysql(EquipId);
            GameObject equipAttribute=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute"), BagController.S.transform);
            GameObject equipAttributeEquip=equipAttribute.transform.Find("EquipAttributeEquip").gameObject;
            GameObject equipAttributeEquipImage=equipAttributeEquip.transform.Find("EquipAttributeEquipImage").gameObject;
            equipAttributeEquipImage.GetComponent<Image>().sprite = equipAttributeImage;
            GameObject equipAttributeName=equipAttribute.transform.Find("EquipAttributeName").gameObject;
            equipAttributeName.GetComponent<Text>().text = EquipName.EquipNameDic[equipTable.EquipName];
        });
    }

    public void OnClick()
    {
        //transform.Find("BagGridImage").GetComponent<Image>().
    }
}
