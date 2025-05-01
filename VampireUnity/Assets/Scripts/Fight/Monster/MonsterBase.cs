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
    private int _currentHp;//当前血量
    private int _maxHp;//最大血量
    private float _speed;//速度
    private int _attack;//攻击力
    private int _defense;//防御力
    private int _exp;//经验值
    private int _bloodEnergy;//血能
    private int _evolutionEnergy;//源能
    public SpriteRenderer monsterSpriteRenderer;
    public Animator monsterAnimator;

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
                        monsterSpriteRenderer.flipX = false;
                    }
                    else
                    {
                        monsterSpriteRenderer.flipX = true;
                    }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
                    {
                        monsterSpriteRenderer.flipX = true;
                    }
                    else
                    {
                        monsterSpriteRenderer.flipX = false;
                    }
        }
        
    }

    //动画事件，设置isHurt
    public void SetIsHurt()
    {
        monsterAnimator.SetBool("isHurt", false);
    }

    public void Hurt(int damage)
    {
        //设置monsterAnimator的ishuru为true
        monsterAnimator.SetBool("isHurt", true);
        //重新播放Hurt动画
        monsterAnimator.Play("SnotMonsterHit");
        _currentHp -= damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletBase bullet = other.gameObject.GetComponent<BulletBase>();
            Hurt(bullet.damage);
            //销毁子弹
            Destroy(other.gameObject);
        }
    }
}
