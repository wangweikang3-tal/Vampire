using System;
using Equip;
using UnityEngine;

public class VacantEye : MonsterBase
{
    [NonSerialized]public VacantEyeBullet VacantEyeBullet;
    public VacantEye() : base(MonsterType.Boss, "VacantEye", 1, 10000, 0.3f, 20, 5, 50, 10, 100) { }
    
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip("PrimaryClothFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryRingFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryCloakFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryShoeFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryNecklaceFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryHelmetFight", 10));
    }

    public void ShotBullet()
    {
        //向四周发射vacantEyeBullet，发射8颗
        for (int i = 0; i < 12; i++)
        {
            float angle = i * 30f;
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            VacantEyeBullet bullet = Instantiate(VacantEyeBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<VacantEyeBullet>().SetDirection(direction);
            bullet.gameObject.SetActive(true);
        }
    }   
    private void Start()
    {
        VacantEyeBullet=Resources.Load<VacantEyeBullet>("Prefabs/Monster/VacantEyeBullet");
        AddMonsterEquip();
    }
    void Update()
    {
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
        //每隔1秒发射一次子弹
        if (Time.frameCount%100==0)
        {
            ShotBullet();
        }
    }
    
}
