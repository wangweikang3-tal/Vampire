using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int _playerSpeed = 3;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GunBase currentGun;
    private float _gunDistance = 0.5f;
    private Queue<MonsterBase> _monsterDetetor1 ;
    private Queue<MonsterBase> _monsterDetetor2 ;
    private Queue<MonsterBase> _monsterDetetor3 ;

    private void Awake()
    {
        currentGun = Instantiate(Resources.Load<GameObject>("Prefabs/Gun/Pistol").GetComponent<GunBase>(),transform);
        _monsterDetetor1 = new Queue<MonsterBase>();
        _monsterDetetor2 = new Queue<MonsterBase>();
        _monsterDetetor3 = new Queue<MonsterBase>();
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
        GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * _playerSpeed;
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
        if (transform.position.x < -15f)
            transform.position = new Vector3(-15f, transform.position.y, transform.position.z);
        if (transform.position.x > 15f)
            transform.position = new Vector3(15f, transform.position.y, transform.position.z);
        if (transform.position.y < -7.5f)
            transform.position = new Vector3(transform.position.x, -7.5f, transform.position.z);
        if (transform.position.y > 7.5f)
            transform.position = new Vector3(transform.position.x, 7.5f, transform.position.z);
            
    }
    
    public void SetSpeed(int speed)
    {
        _playerSpeed = speed;
    }
    
    public void SetGunRotate(Vector3 targetPosition)
    {
        //获取鼠标位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //主角朝鼠标方向
        Vector3 direction = (mousePos - transform.position).normalized;
        //设置枪的位置
        currentGun.transform.position = transform.position + direction * _gunDistance;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        currentGun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
}
