using System;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private float _speed;
    private int _damage;
    //构造函数
    public BulletBase(float speed, int damage)
    {
        this._speed = speed;
        this._damage = damage;
    }
    public void BulletMove()
    {
        //朝当前方向右边移动
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void Update()
    {
        BulletMove();
    }
}
