using UnityEngine;

public class GunBase : MonoBehaviour
{
    private float _attackSpeed;
    public BulletBase _bullet;

    public SpriteRenderer gunSpriteRender;
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
        BulletBase bullet=Instantiate(Resources.Load<BulletBase>("Prefabs/Bullet/PistolBullet"),GameController.S.gamePlayer.currentGun.transform);
        if (GameController.S.gamePlayer.currentGun.gunSpriteRender.flipY)
            bullet.transform.localPosition=new Vector3(bullet.transform.localPosition.x,-2,bullet.transform.localPosition.z);
        bullet.BulletMove();
    }
    
}
