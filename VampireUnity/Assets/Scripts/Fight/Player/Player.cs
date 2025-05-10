using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GunBase currentGun;
    private float _gunDistance = 0.3f;

    private void Awake()
    {
        currentGun = Instantiate(Resources.Load<GameObject>("Prefabs/Gun/Pistol").GetComponent<GunBase>(),transform);
        
    }
    
    /// <summary>
    /// 主角动画
    /// </summary>
    public void PlayerMoveAnimation()
    {
        //获得输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal == 0&& vertical == 0)
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
        }
    }
    
    /// <summary>
    /// 主角移动
    /// </summary>
    public void PlayerMove()
    {
        //获得输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //刚体移动角色
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        //刚体移动
        GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * GlobalPlayerAttribute.PlayerMoveSpeed;
        if (horizontal < 0)
        {
            //翻转Sprite
            spriteRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        
        //限制角色在屏幕内
        if (transform.position.x < -16f)
            transform.position = new Vector3(-16f, transform.position.y, transform.position.z);
        if (transform.position.x > 16f)
            transform.position = new Vector3(16f, transform.position.y, transform.position.z);
        if (transform.position.y < -8.5f)
            transform.position = new Vector3(transform.position.x, -8.5f, transform.position.z);
        if (transform.position.y > 8.5f)
            transform.position = new Vector3(transform.position.x, 8.5f, transform.position.z);
            
    }
    
    public void SetGunRotate(Vector3 nearMonsterPosition)
    {
        //主角朝最近怪物的方向
        Vector3 direction = (nearMonsterPosition - transform.position).normalized;
        //设置枪的位置
        currentGun.transform.position = transform.position + direction * _gunDistance;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //如果角度在90-270之间
        if (angle > 90 || angle <-90)
        {
           currentGun.gunSpriteRender.flipY = true;
        }
        else
        {
            currentGun.gunSpriteRender.flipY = false;
        }
        currentGun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
}
