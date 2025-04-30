using System;
using UnityEngine;
//怪物类型枚举
public enum MonsterType
{
    None = 0,
    Normal = 1,
    Elite = 2,
    Boss = 3,
}
public class MonsterBase : MonoBehaviour
{
    public int monsterType;//怪物类型
    public string monsterName;//怪物名称
    public int monsterLevel;//怪物等级
    public int currentHp;//当前血量
    public int maxHp;//最大血量
    public int speed;//速度
    public int attack;//攻击力
    public int defense;//防御力
    public int exp;//经验值
    public int bloodEnergy;//血能
    public int evolutionEnergy;//源能
    //构造方法
    public MonsterBase(int monsterType, string monsterName, int monsterLevel, int maxHp, int speed, int attack, int defense, int exp, int bloodEnergy, int evolutionEnergy)
    {
        this.monsterType = monsterType;
        this.monsterName = monsterName;
        this.monsterLevel = monsterLevel;
        this.maxHp = maxHp;
        this.speed = speed;
        this.attack = attack;
        this.defense = defense;
        this.exp = exp;
        this.bloodEnergy = bloodEnergy;
        this.evolutionEnergy = evolutionEnergy;
    }

    public void MonsterMove()
    {
        //朝着主角以speed的速度前进
        Vector3 direction = GameController.S.GamePlayer.transform.position - transform.position;
        //刚体移动
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed; 
    }
}
