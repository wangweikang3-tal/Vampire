public class EquipTable
{
    public int Equipid { get; set; }
    public int Quality { get; set; }
    public int Damage { get; set; }
    public int CRIT { get; set; }
    public int CRITDamage { get; set; }
    public int DamageSpeed { get; set; }
    public int BloodSuck { get; set; }
    public int Denfense { get; set; }
    public int HP { get; set; }
    public int MoveSpeed { get; set; }
    public int GoodFortune { get; set; }

    public EquipTable(
        int equipid = 0, 
        int quality = 0, 
        int damage = 0, 
        int crit = 0, 
        int critdamage = 0, 
        int damagespeed = 0, 
        int bloodsuck = 0, 
        int denfense = 0, 
        int hp = 0, 
        int movespeed = 0, 
        int goodfortune = 0)
    {
        Equipid = equipid;
        Quality = quality;
        Damage = damage;
        CRIT = crit;
        CRITDamage = critdamage;
        DamageSpeed = damagespeed;
        BloodSuck = bloodsuck;
        Denfense = denfense;
        HP = hp;
        MoveSpeed = movespeed;
        GoodFortune = goodfortune;
    }
}