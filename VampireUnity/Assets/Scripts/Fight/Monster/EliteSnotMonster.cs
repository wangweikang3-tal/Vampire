using System;
using Equip;
using UnityEngine;

public class EliteSnotMonster : MonsterBase
{
    public EliteSnotMonster() : base(MonsterType.Elite, "EliteSnotMonster", 1, 1000, 0.3f, 20, 5, 50, 100, 10) { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip("PrimaryClothFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryRingFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryCloakFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryShoeFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryNecklaceFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryHelmetFight", 10));
    }

    public void Start()
    {
        AddMonsterEquip();
    }
    void Update()
    {
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }
}
