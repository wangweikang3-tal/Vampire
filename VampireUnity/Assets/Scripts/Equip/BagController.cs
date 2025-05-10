using System;
using System.Collections.Generic;
using Mysql;
using Tool;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BagController : XSingleton<BagController>
{
    [NonSerialized] public Dictionary<int, Sprite> EquipidDic = new Dictionary<int, Sprite>(); //背包里所有的装备
    [NonSerialized] public GameObject bagGrid; //背包格子
    [NonSerialized] public GameObject bag; //背包
    [NonSerialized] public GameObject MaskLayer; //蒙层
    [NonSerialized] public bool IsShowPlayerPanel = true;
    [NonSerialized] public GameObject PlayerPanel; //玩家面板
    [NonSerialized] public GameObject AttributePanel; //属性面板
    public GameObject playerCloth; //玩家面板的衣服
    public GameObject playerCloak; //玩家面板的披风
    public GameObject playerRing;
    public GameObject playerNecklace;
    public GameObject playerShoe;
    public GameObject playerHelmet;
    [NonSerialized] private bool IsInstallCloth = false; //是否穿了衣服
    [NonSerialized] private bool IsInstallCloak = false;
    [NonSerialized] private bool IsInstallRing = false;
    [NonSerialized] private bool IsInstallNecklace = false;
    [NonSerialized] private bool IsInstallShoe = false;
    [NonSerialized] private bool IsInstallHelmet = false;

    //player穿的装备的属性
    [NonSerialized] public EquipTable PlayerClothAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerCloakAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerRingAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerNecklaceAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerShoeAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerHelmetAttribute=new EquipTable();
    




    protected override void Awake()
    {
        bag = Instantiate(Resources.Load("Prefabs/Window/Bag"), GameObject.Find("UIRoot").transform).GameObject();
        bag.gameObject.SetActive(false);
        bagGrid = Resources.Load("Prefabs/Equip/BagGrid") as GameObject;
        PlayerPanel = bag.transform.Find("BagPanel").Find("PlayerPanel").gameObject;
        AttributePanel = bag.transform.Find("BagPanel").Find("AttributePanel").gameObject;
        playerCloth = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Cloth").gameObject;
        playerCloak = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Cloak").gameObject;
        playerRing = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Ring").gameObject;
        playerNecklace = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Necklace").gameObject;
        playerShoe = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Shoe").gameObject;
        playerHelmet = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Helmet").gameObject;
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
        MaskLayer = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/MaskLayer"), transform);
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
            GameObject bagGridins = Instantiate(bagGrid, equipContent.transform);
            bagGridins.GetComponent<BagGrid>().EquipId = equip.Key;
            bagGridins.GetComponent<BagGrid>().equipAttributeImage = equip.Value;
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
        playerCloth.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { ShowEquipAttributePanel(equipId); });
    }

    public void InstallCloak(int equipId)
    {
        IsInstallCloak = true;
        playerCloak.transform.Find("Image").gameObject.SetActive(true);
        playerCloak.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerCloak.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { ShowEquipAttributePanel(equipId); });
    }

    public void InstallRing(int equipId)
    {
        IsInstallRing = true;
        playerRing.transform.Find("Image").gameObject.SetActive(true);
        playerRing.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerRing.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { ShowEquipAttributePanel(equipId); });
    }

    public void InstallNecklace(int equipId)
    {
        IsInstallNecklace = true;
        playerNecklace.transform.Find("Image").gameObject.SetActive(true);
        playerNecklace.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerNecklace.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { ShowEquipAttributePanel(equipId); });
    }

    public void InstallShoe(int equipId)
    {
        IsInstallShoe = true;
        playerShoe.transform.Find("Image").gameObject.SetActive(true);
        playerShoe.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerShoe.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { ShowEquipAttributePanel(equipId); });
    }

    public void InstallHelmet(int equipId)
    {
        IsInstallHelmet = true;
        playerHelmet.transform.Find("Image").gameObject.SetActive(true);
        playerHelmet.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidDic[equipId];
        playerHelmet.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { ShowEquipAttributePanel(equipId);});
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

    public void ShowEquipAttributePanel(int EquipId)
    {
        EquipTable equipTable = EquipController.S.GetEquipAttributeFromMysql(EquipId);
        GameObject equipAttribute = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute"),
            BagController.S.transform);
        equipAttribute.GetComponent<EquipAttributePanel>().CurrentequipId = EquipId; //当前装备ID传给属性面板
        GameObject equipAttributeEquip = equipAttribute.transform.Find("EquipAttributeEquip").gameObject;
        GameObject equipAttributeEquipImage = equipAttributeEquip.transform.Find("EquipAttributeEquipImage").gameObject;
        equipAttributeEquipImage.GetComponent<Image>().sprite = GetEquipSprite(equipTable.EquipName);
        GameObject equipAttributeName = equipAttribute.transform.Find("EquipAttributeName").gameObject;
        equipAttributeName.GetComponent<Text>().text = EquipName.EquipNameDic[equipTable.EquipName];
        GameObject equipAttributeContent =
            equipAttribute.transform.Find("ScrollView").Find("Viewport").Find("Content").gameObject;
        if (equipTable.Damage != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "攻击力：" + equipTable.Damage;
        }

        if (equipTable.HP != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "生命值：" + equipTable.HP;
        }

        if (equipTable.Denfense != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "防御力：" + equipTable.Denfense;
        }

        if (equipTable.CRIT != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "暴击率：" + equipTable.CRIT;
        }

        if (equipTable.CRITDamage != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "暴击伤害：" + equipTable.CRITDamage;
        }

        if (equipTable.BloodSuck != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "吸血：" + equipTable.BloodSuck;
        }

        if (equipTable.GoodFortune != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "幸运：" + equipTable.GoodFortune;
        }

        if (equipTable.MoveSpeed != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "移动速度：" + equipTable.MoveSpeed;
        }

        if (equipTable.DamageSpeed != 0)
        {
            GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                equipAttributeContent.transform);
            EquipAttributeItem.GetComponent<Text>().text = "攻击速度：" + equipTable.DamageSpeed;
        }
    }
    
    public Sprite GetEquipSprite(string equipName)
    {
        if (equipName == "PrimaryCloth")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryClothFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryClothSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryCloak")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryCloakhFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryCloakSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryRing")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryRingFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryRingSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryNecklace")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryNecklaceFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryNecklaceSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryShoe")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryShoeFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryShoeSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryHelmet")
        { 
            GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryHelmetFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryHelmetSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        // 如果未找到匹配项或出现问题，返回 null
        return null;
    }

    public void ComputeEquipAttribute()
    {
        GlobalPlayerAttribute.EquipDamage=PlayerClothAttribute.Damage+PlayerCloakAttribute.Damage+
            PlayerRingAttribute.Damage+PlayerNecklaceAttribute.Damage+PlayerShoeAttribute.Damage+
            PlayerHelmetAttribute.Damage;
        GlobalPlayerAttribute.EquipMaxHp=PlayerClothAttribute.HP+PlayerCloakAttribute.HP+
            PlayerRingAttribute.HP+PlayerNecklaceAttribute.HP+PlayerShoeAttribute.HP+
            PlayerHelmetAttribute.HP;
        GlobalPlayerAttribute.EquipMoveSpeed=PlayerClothAttribute.MoveSpeed+PlayerCloakAttribute.MoveSpeed+
            PlayerRingAttribute.MoveSpeed+PlayerNecklaceAttribute.MoveSpeed+PlayerShoeAttribute.MoveSpeed+
            PlayerHelmetAttribute.MoveSpeed;
        GlobalPlayerAttribute.EquipAttackSpeed=PlayerClothAttribute.DamageSpeed+PlayerCloakAttribute.DamageSpeed+
            PlayerRingAttribute.DamageSpeed+PlayerNecklaceAttribute.DamageSpeed+PlayerShoeAttribute.DamageSpeed+
            PlayerHelmetAttribute.DamageSpeed;
        GlobalPlayerAttribute.EquipCRIT=PlayerClothAttribute.CRIT+PlayerCloakAttribute.CRIT+
            PlayerRingAttribute.CRIT+PlayerNecklaceAttribute.CRIT+PlayerShoeAttribute.CRIT+
            PlayerHelmetAttribute.CRIT;
        GlobalPlayerAttribute.EquipCRITDamage=PlayerClothAttribute.CRITDamage+PlayerCloakAttribute.CRITDamage+
            PlayerRingAttribute.CRITDamage+PlayerNecklaceAttribute.CRITDamage+PlayerShoeAttribute.CRITDamage+
            PlayerHelmetAttribute.CRITDamage; 
        GlobalPlayerAttribute.EquipBloodSuck=PlayerClothAttribute.BloodSuck+PlayerCloakAttribute.BloodSuck+
            PlayerRingAttribute.BloodSuck+PlayerNecklaceAttribute.BloodSuck+PlayerShoeAttribute.BloodSuck+
            PlayerHelmetAttribute.BloodSuck;
        GlobalPlayerAttribute.EquipDenfense=PlayerClothAttribute.Denfense+PlayerCloakAttribute.Denfense+
            PlayerRingAttribute.Denfense+PlayerNecklaceAttribute.Denfense+PlayerShoeAttribute.Denfense+
            PlayerHelmetAttribute.Denfense;
        GlobalPlayerAttribute.EquipGoodFortune=PlayerClothAttribute.GoodFortune+PlayerCloakAttribute.GoodFortune+
            PlayerRingAttribute.GoodFortune+PlayerNecklaceAttribute.GoodFortune+PlayerShoeAttribute.GoodFortune+
            PlayerHelmetAttribute.GoodFortune;
    }

    public void ComputeTotalAttribute()
    {
        ComputeEquipAttribute();
        GlobalPlayerAttribute.TotalDamage = GlobalPlayerAttribute.PlayerDamage + GlobalPlayerAttribute.EquipDamage;
        GlobalPlayerAttribute.TotalMaxHp = GlobalPlayerAttribute.PlayerMaxHp + GlobalPlayerAttribute.EquipMaxHp;
        GlobalPlayerAttribute.TotalMoveSpeed = GlobalPlayerAttribute.PlayerMoveSpeed + GlobalPlayerAttribute.EquipMoveSpeed;
        GlobalPlayerAttribute.TotalAttackSpeed = GlobalPlayerAttribute.PlayerAttackSpeed + GlobalPlayerAttribute.EquipAttackSpeed;
        GlobalPlayerAttribute.TotalCRIT = GlobalPlayerAttribute.PlayerCRIT + GlobalPlayerAttribute.EquipCRIT;
        GlobalPlayerAttribute.TotalCRITDamage = GlobalPlayerAttribute.PlayerCRITDamage + GlobalPlayerAttribute.EquipCRITDamage;
        GlobalPlayerAttribute.TotalBloodSuck = GlobalPlayerAttribute.PlayerBloodSuck + GlobalPlayerAttribute.EquipBloodSuck;
        GlobalPlayerAttribute.TotalDenfense = GlobalPlayerAttribute.PlayerDenfense + GlobalPlayerAttribute.EquipDenfense;
        GlobalPlayerAttribute.TotalGoodFortune = GlobalPlayerAttribute.PlayerGoodFortune + GlobalPlayerAttribute.EquipGoodFortune;
    }

    
}
