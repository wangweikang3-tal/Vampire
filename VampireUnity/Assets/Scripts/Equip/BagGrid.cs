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
            BagController.S.ShowEquipAttributePanel(EquipId);
        });
    }

    public void OnClick()
    {
        //transform.Find("BagGridImage").GetComponent<Image>().
    }
}
