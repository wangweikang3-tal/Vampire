using System;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speed;
    public int damage;
    //构造函数
    public BulletBase(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }
    public void BulletMove()
    {
        //朝当前方向右边移动
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        BulletMove();
    }
}
