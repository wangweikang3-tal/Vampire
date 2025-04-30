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
    private MonsterType _monsterType;//怪物类型
    private string _monsterName;//怪物名称
    private int _monsterLevel;//怪物等级
    private int c_urrentHp;//当前血量
    private int _maxHp;//最大血量
    private float _speed;//速度
    private int _attack;//攻击力
    private int _defense;//防御力
    private int _exp;//经验值
    private int _bloodEnergy;//血能
    private int _evolutionEnergy;//源能
    public SpriteRenderer spriteRenderer;

    //构造方法
    public MonsterBase(MonsterType monsterType, string monsterName, int monsterLevel, int maxHp, float speed, int attack, int defense, int exp, int bloodEnergy, int evolutionEnergy)
    {
        this._monsterType = monsterType;
        this._monsterName = monsterName;
        this._monsterLevel = monsterLevel;
        this._maxHp = maxHp;
        this._speed = speed;
        this._attack = attack;
        this._defense = defense;
        this._exp = exp;
        this._bloodEnergy = bloodEnergy;
        this._evolutionEnergy = evolutionEnergy;
    }

    public void MonsterMove()
    {
        //朝着主角以speed的速度前进
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        //刚体移动
        GetComponent<Rigidbody2D>().velocity = direction.normalized * _speed; 
    }
    
    public void SpriteFlipX(bool isRight)
    {
        //翻转精灵
        if (isRight)
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
                    {
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipX = true;
                    }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                    }
        }
        
    }
}
