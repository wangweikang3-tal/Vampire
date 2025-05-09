using System;
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
                    BagController.S.InstallCloth(CurrentequipId);
                    break;
                case 5:
                    BagController.S.InstallShoe(CurrentequipId);
                    break;
                case 6:
                    BagController.S.InstallRing(CurrentequipId);
                    break;
                case 7:
                    BagController.S.InstallNecklace(CurrentequipId);
                    break;
                case 8:
                    BagController.S.InstallHelmet(CurrentequipId);
                    break;
                case 9:
                    BagController.S.InstallCloak(CurrentequipId);
                    break;
            }
            BagController.S.DestroyMaskLayer();
            Destroy(gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
