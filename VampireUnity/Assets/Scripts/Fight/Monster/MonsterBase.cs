using System;
using UnityEngine;
using UnityEngine.UI;

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
    [NonSerialized]public MonsterType MonsterType;//怪物类型
    [NonSerialized]public string MonsterName;//怪物名称
    [NonSerialized]public int MonsterLevel;//怪物等级
    [NonSerialized]public int CurrentHp;//当前血量
    [NonSerialized]public  int MaxHp;//最大血量
    [NonSerialized]public float Speed;//速度
    [NonSerialized]public int Attack;//攻击力
    [NonSerialized]public int Defense;//防御力
    [NonSerialized]public int Exp;//经验值
    [NonSerialized]public int BloodEnergy;//血能
    [NonSerialized]public int EvolutionEnergy;//源能
    [NonSerialized]public bool IsDead=false;//是否死亡
    public SpriteRenderer monsterSpriteRenderer;
    public Animator monsterAnimator;
    public GameObject monsterHurtText;
    public Slider hpSlider;

    //构造方法
    public MonsterBase(MonsterType monsterType, string monsterName, int monsterLevel, int maxHp, float speed, int attack, int defense, int exp, int bloodEnergy, int evolutionEnergy)
    {
        this.MonsterType = monsterType;
        this.MonsterName = monsterName;
        this.MonsterLevel = monsterLevel;
        this.MaxHp = maxHp;
        this.Speed = speed;
        this.Attack = attack;
        this.Defense = defense;
        this.Exp = exp;
        this.BloodEnergy = bloodEnergy;
        this.EvolutionEnergy = evolutionEnergy;
    }

    private void Awake()
    {
        monsterHurtText=Resources.Load<GameObject>("Prefabs/Tool/MonsterHurtText");
    }
    public void MonsterMove()
    {
        //朝着主角以speed的速度前进
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        //刚体移动
        GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
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
    //动画事件，销毁怪物
    public void DestroyMonster()
    {
        Destroy(this.gameObject);
    }

    public void Die()
    {
        //生成血能
        GameObject bloodEnergy = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BloodEnergy"));
        //设置血能位置为怪物位置
        bloodEnergy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        IsDead = true;
        // 从所有探测器列表中移除自己
        // 立即从所有探测器列表中移除自己
        if (GameController.S != null)
        {
            GameController.S.monsterDetetor1.RemoveAll(m => m == this);
            GameController.S.monsterDetetor2.RemoveAll(m => m == this);
            GameController.S.monsterDetetor3.RemoveAll(m => m == this);
        }
        // 禁用碰撞器，防止继续触发碰撞
        if(GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().enabled = false;
        
        // 禁用移动
        if(GetComponent<Rigidbody2D>() != null)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        monsterAnimator.SetBool("isDead", true);
        //播放死亡动画
        monsterAnimator.Play("SnotMonsterDead");
    }

    public void Hurt(int damage)
    {
        GameObject monsterHpGameObject=Instantiate(monsterHurtText, transform);
        //在monsterHpGameObject子类中查找Canvas的紫累HPText
        Text monsterHpText = monsterHpGameObject.transform.Find("Canvas/HPText").GetComponent<Text>();
        //设置monsterHpText的text为-damage
        monsterHpText.text = "-" + damage.ToString();
        //设置monsterHpGameObject的position为怪物位置
        monsterHpGameObject.transform.position = new Vector3(transform.position.x+0.1f, transform.position.y + 0.2f, transform.position.z);
        //设置monsterAnimator的ishuru为true
        monsterAnimator.SetBool("isHurt", true);
        //重新播放Hurt动画
        monsterAnimator.Play("SnotMonsterHit");
        CurrentHp -= damage;
        //设置血条
        hpSlider.value = (float)CurrentHp / MaxHp;
        if(CurrentHp<=0)
            Die();
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
