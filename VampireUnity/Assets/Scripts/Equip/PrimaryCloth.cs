using System;

namespace Equip
{
    public class PrimaryCloth:EquipBase
    {
        public PrimaryCloth() : base(equipID: 1, "aaa", new FightEquipAttribute()){}

        private void Awake()
        {
            EquipAttributes.EquipQuality = EquipQuality.White;
            EquipAttributes.Attributes.Add(EquipAttribute.HP, 10);
            EquipAttributes.Attributes.Add(EquipAttribute.Denfense, 10);
        }
    }
}