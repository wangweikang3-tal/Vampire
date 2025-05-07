using System;

namespace Equip
{
    public class PrimaryCloth:EquipBase
    {
        public PrimaryCloth() : base(equipID: 1, "PrimaryClothFight", new FightEquipAttribute()){}

        private void Awake()
        {
            EquipAttributes.EquipQuality = EquipQuality.White;
            //添加防御，随机10-20
            Random random = new Random();
            EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
            //添加生命值，随机10-20
            EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        }
    }
}