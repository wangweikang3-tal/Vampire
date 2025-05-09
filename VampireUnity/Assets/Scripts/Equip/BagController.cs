using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BagController : XSingleton<BagController>
{
    [NonSerialized]public Dictionary<int, Sprite> EquipidDic = new Dictionary<int, Sprite>();//背包里所有的装备
    [NonSerialized]public GameObject bagGrid;//背包格子
    [NonSerialized]public GameObject bag;//背包
    [NonSerialized] public GameObject MaskLayer;//蒙层
    [NonSerialized] public bool IsShowPlayerPanel = true;
    [NonSerialized] public GameObject PlayerPanel ;//玩家面板
    [NonSerialized] public GameObject AttributePanel ;//属性面板
    public GameObject playerCloth;//玩家面板的衣服
    public GameObject playerCloak; //玩家面板的披风
    public GameObject playerRing;
    public GameObject playerNecklace;
    public GameObject playerShoe;
    public GameObject playerHelmet;
    [NonSerialized] private bool IsInstallCloth = false;//是否穿了衣服
    [NonSerialized] private bool IsInstallCloak = false;
    [NonSerialized] private bool IsInstallRing = false;
    [NonSerialized] private bool IsInstallNecklace = false;
    [NonSerialized] private bool IsInstallShoe = false;
    [NonSerialized] private bool IsInstallHelmet = false;



    protected override void Awake()
    {
        bag=Instantiate(Resources.Load("Prefabs/Window/Bag"),GameObject.Find("UIRoot").transform).GameObject();
        bag.gameObject.SetActive(false);
        bagGrid = Resources.Load("Prefabs/Equip/BagGrid")as GameObject;
        PlayerPanel=bag.transform.Find("BagPanel").Find("PlayerPanel").gameObject;
        AttributePanel=bag.transform.Find("BagPanel").Find("AttributePanel").gameObject;
        playerCloth=bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Cloth").gameObject;
        playerCloak=bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Cloak").gameObject;
        playerRing=bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Ring").gameObject;
        playerNecklace=bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Necklace").gameObject;
        playerShoe=bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Shoe").gameObject;
        playerHelmet=bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Helmet").gameObject;
    }

    /// <summary>
    /// 显示玩家面板
    /// </summary>
    public void ShowPlayerPanel()
    {
        IsShowPlayerPanel = true;
        PlayerPanel.gameObject.SetActive(true);
        AttributePanel.gameObject.SetActive(false);

    }

    /// <summary>
    /// 显示属性面板
    /// </summary>
    public void ShowAttributePanel()
    {
        IsShowPlayerPanel = false;
        PlayerPanel.gameObject.SetActive(false);
        AttributePanel.gameObject.SetActive(true);
    }
    /// <summary>
    /// 生成蒙层
    /// </summary>
    public void CreateMaskLayer()
    {
        MaskLayer= Instantiate(Resources.Load<GameObject>("Prefabs/Equip/MaskLayer"), transform);
    }

    /// <summary>
    /// 销毁蒙层
    /// </summary>
    public void DestroyMaskLayer()
    {
        Destroy(MaskLayer);
    }


    /// <summary>
    /// 显示背包的装备
    /// </summary>
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

    /// <summary>
    /// 打开背包面板
    /// </summary>
    public void ShowBag()
    {
        //暂停游戏
        Time.timeScale = 0;
        bag.gameObject.SetActive(true);
        ShowEquip();
    }

    /// <summary>
    /// 隐藏背包面板
    /// </summary>
    public void HideBag()
    {
        //暂停游戏
        Time.timeScale = 1;
        bag.gameObject.SetActive(false);
    }

    
    /// <summary>
    /// 装装备
    /// </summary>
    /// <param name="equipId"></param>
    public void InstallCloth(int equipId)
    {
        IsInstallCloth = true;
        playerCloth.transform.Find("Image").gameObject.SetActive(true);
        playerCloth.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerCloth.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("1111");
        });
    }
    public void InstallCloak(int equipId)
    {
        IsInstallCloak = true;
        playerCloak.transform.Find("Image").gameObject.SetActive(true);
        playerCloak.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerCloak.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("2222");
        });
    }
    public void InstallRing(int equipId)
    {
        IsInstallRing = true;
        playerRing.transform.Find("Image").gameObject.SetActive(true);
        playerRing.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerRing.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("3333");
        });
    }
    public void InstallNecklace(int equipId)
    {
        IsInstallNecklace = true;
        playerNecklace.transform.Find("Image").gameObject.SetActive(true);
        playerNecklace.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerNecklace.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("4444");
        });
    }
    public void InstallShoe(int equipId)
    {
        IsInstallShoe = true;
        playerShoe.transform.Find("Image").gameObject.SetActive(true);
        playerShoe.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerShoe.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("5555");
        });
    }
    public void InstallHelmet(int equipId)
    {
        IsInstallHelmet = true;
        playerHelmet.transform.Find("Image").gameObject.SetActive(true);
        playerHelmet.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerHelmet.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("6666");
        });
    }
    /// <summary>
    /// 卸装备
    /// </summary>
    public void UnInstallCloth()
    {
        IsInstallCloth = false;
        playerCloth.transform.Find("Image").gameObject.SetActive(false);
        playerCloth.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }
    public void UnInstallCloak()
    {
        IsInstallCloak = false;
        playerCloak.transform.Find("Image").gameObject.SetActive(false);
        playerCloak.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }
    public void UnInstallRing()
    {
        IsInstallRing = false;
        playerRing.transform.Find("Image").gameObject.SetActive(false);
        playerRing.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }
    public void UnInstallNecklace()
    {
        IsInstallNecklace = false;
        playerNecklace.transform.Find("Image").gameObject.SetActive(false);
        playerNecklace.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }
    public void UnInstallShoe()
    {
        IsInstallShoe = false;
        playerShoe.transform.Find("Image").gameObject.SetActive(false);
        playerShoe.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }
    public void UnInstallHelmet()
    {
        IsInstallHelmet = false;
        playerHelmet.transform.Find("Image").gameObject.SetActive(false);
        playerHelmet.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }
    
    
    
}
