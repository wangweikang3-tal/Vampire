using UnityEngine;

public class GunBase : MonoBehaviour
{
    private float _attackSpeed;
    public BulletBase _bullet;
    //构造方法
    public GunBase(float attackSpeed)
    {
        this._attackSpeed = attackSpeed;
    }
    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    public void Shot()
    {
        //实例化子弹
        BulletBase bullet = Instantiate(Resources.Load<BulletBase>("Prefabs/Bullet/PistolBullet"),GameController.S.gamePlayer.currentGun.transform);
        bullet.BulletMove();
    }
    
}
