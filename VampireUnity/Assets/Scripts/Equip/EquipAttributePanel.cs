using System;
using Mysql;
using UnityEngine;
using UnityEngine.UI;

public class EquipAttributePanel : MonoBehaviour
{
    public Button exitButton;
    public Button installButton;
    public Button sellButton;
    [NonSerialized]public int CurrentequipId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            Destroy(gameObject);
            BagController.S.DestroyMaskLayer();
        });
        installButton.onClick.AddListener(() =>
        {
            //获取equipid的第一个数字
            int equiptype = CurrentequipId / 10000000;
            switch (equiptype)
            {
                case 4:
                    //将这个装备的属性传到Bagtroller
                    BagController.S.PlayerClothAttribute = EquipController.S.GetEquipAttributeFromMysql(CurrentequipId);
                    BagController.S.InstallCloth(CurrentequipId);
                    break;
                case 5:
                    //将这个装备的属性传到Bagtroller
                    BagController.S.PlayerShoeAttribute = EquipController.S.GetEquipAttributeFromMysql(CurrentequipId);
                    BagController.S.InstallShoe(CurrentequipId);
                    break;
                case 6:
                    //将这个装备的属性传到Bagtroller
                    BagController.S.PlayerRingAttribute = EquipController.S.GetEquipAttributeFromMysql(CurrentequipId);
                    BagController.S.InstallRing(CurrentequipId);
                    break;
                case 7:
                    BagController.S.PlayerNecklaceAttribute = EquipController.S.GetEquipAttributeFromMysql(CurrentequipId);
                    BagController.S.InstallNecklace(CurrentequipId);
                    break;
                case 8:
                    BagController.S.PlayerHelmetAttribute = EquipController.S.GetEquipAttributeFromMysql(CurrentequipId);
                    BagController.S.InstallHelmet(CurrentequipId);
                    break;
                case 9:
                    BagController.S.PlayerCloakAttribute = EquipController.S.GetEquipAttributeFromMysql(CurrentequipId);
                    BagController.S.InstallCloak(CurrentequipId);
                    break;
            }
            BagController.S.ComputeTotalAttribute();//更新人物和装备属性
            BagController.S.DestroyMaskLayer();
            Destroy(gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
