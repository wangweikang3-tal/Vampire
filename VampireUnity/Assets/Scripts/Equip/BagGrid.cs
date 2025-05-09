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
            //生成蒙层
            BagController.S.CreateMaskLayer();
            //显示装备属性面板
            EquipTable equipTable = EquipController.S.GetEquipAttributeFromMysql(EquipId);
            GameObject equipAttribute=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute"), BagController.S.transform);
            equipAttribute.GetComponent<EquipAttributePanel>().CurrentequipId = EquipId;//当前装备ID传给属性面板
            GameObject equipAttributeEquip=equipAttribute.transform.Find("EquipAttributeEquip").gameObject;
            GameObject equipAttributeEquipImage=equipAttributeEquip.transform.Find("EquipAttributeEquipImage").gameObject;
            equipAttributeEquipImage.GetComponent<Image>().sprite = equipAttributeImage;
            GameObject equipAttributeName=equipAttribute.transform.Find("EquipAttributeName").gameObject;
            equipAttributeName.GetComponent<Text>().text = EquipName.EquipNameDic[equipTable.EquipName];
            GameObject equipAttributeContent=equipAttribute.transform.Find("ScrollView").Find("Viewport").Find("Content").gameObject;
            if (equipTable.Damage != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="攻击力："+equipTable.Damage;
            }
            if (equipTable.HP != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="生命值："+equipTable.HP;
            }
            if (equipTable.Denfense != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="防御力："+equipTable.Denfense;
            }
            if (equipTable.CRIT != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="暴击率："+equipTable.CRIT;
            }
            if (equipTable.CRITDamage != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="暴击伤害："+equipTable.CRITDamage;
            }
            if (equipTable.BloodSuck != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="吸血："+equipTable.BloodSuck;
            }
            if (equipTable.GoodFortune != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="幸运："+equipTable.GoodFortune;
            }
            if (equipTable.MoveSpeed != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="移动速度："+equipTable.MoveSpeed;
            }
            if (equipTable.DamageSpeed != 0)
            {
                GameObject EquipAttributeItem=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"), equipAttributeContent.transform);
                EquipAttributeItem.GetComponent<Text>().text="攻击速度："+equipTable.DamageSpeed;
            }
        });
    }

    public void OnClick()
    {
        //transform.Find("BagGridImage").GetComponent<Image>().
    }
}
