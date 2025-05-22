using Equip;


public class SnotMonster : MonsterBase
{
    //构造方法
    public SnotMonster() : base(MonsterType.Normal, "SnotMonster", 1, 100, 0.3f, 10, 5, 10, 10, 0) { }

    private void Start()
    {
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
        MonsterEquipList.Add(new MonsterEquip("PrimaryClothFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryRingFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryCloakFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryShoeFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryNecklaceFight", 10));
        MonsterEquipList.Add(new MonsterEquip("PrimaryHelmetFight", 10));

    }
}
