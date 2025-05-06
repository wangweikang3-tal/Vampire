using System;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class SnotMonster : MonsterBase
{
    //构造方法
    public SnotMonster() : base(MonsterType.Normal, "SnotMonster", 1, 100, 0.3f, 10, 5, 50, 10, 0) { }

    private void Start()
    {
        MonsterEquipList = new List<MonsterEquip>();
        AddMonsterEquip();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip("PrimaryClothFight", 100));
    }
}
