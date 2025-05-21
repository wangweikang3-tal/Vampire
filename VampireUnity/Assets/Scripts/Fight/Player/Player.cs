using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GunBase currentGun;
    private float _gunDistance = 0.3f;
    public Joystick joystick;//虚拟移动杆
    public Button normalAttackButton;//普通攻击按钮
    public Button dashButton;
    public Button rageButton;
    public Button shieldButton;
    public Button iceArrowButton;
    public Button iceExButton;




    private void Awake()
    {
        normalAttackButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.currentGun.Shot();
        });
        dashButton.onClick.AddListener(() =>
        {
            SkillController.S. IsDash = true;
        });
        rageButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        });
        shieldButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
        });
        iceArrowButton.onClick.AddListener(() =>
        {
            SkillController.S.IceArrow.Play();
            SkillController.S.IceArrow.transform.Find("Trail").gameObject.SetActive(true);        });
        iceExButton.onClick.AddListener(() =>
        {
            SkillController.S.IceExplosion1.Play();
            SkillController.S.IceExplosion2.Play();
            SkillController.S.IceExplosion3.Play();        });
        currentGun = Instantiate(Resources.Load<GameObject>("Prefabs/Gun/Pistol").GetComponent<GunBase>(),transform);
    }
    
    /// <summary>
    /// 主角动画
    /// </summary>
    public void PlayerMoveAnimation()
    {
        //获得输入
        Vector2 joydir = joystick.input.normalized;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(joydir==Vector2.zero)
        {
            if(horizontal == 0&& vertical == 0)
            {
                animator.SetBool("isMove", false);
            }
            else
            {
                animator.SetBool("isMove", true);
            }
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
        Vector2 joydir = joystick.input.normalized;
        if (joydir.x > 0)
        {
            spriteRenderer.flipX = false;
        } else if (joydir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (joydir == Vector2.zero)//设置pc和安卓的移动
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(horizontal, vertical).normalized * GlobalPlayerAttribute.PlayerMoveSpeed;
        }
        else
        {
            GetComponent<Rigidbody2D>().linearVelocity = joydir * GlobalPlayerAttribute.PlayerMoveSpeed;
        }
        
        
        // //刚体移动角色
        // Vector3 direction = new Vector3(horizontal, vertical, 0);
        // //刚体移动
        // GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * GlobalPlayerAttribute.PlayerMoveSpeed;
        
        // //限制角色在屏幕内
        // if (transform.position.x < -16f)
        //     transform.position = new Vector3(-16f, transform.position.y, transform.position.z);
        // if (transform.position.x > 16f)
        //     transform.position = new Vector3(16f, transform.position.y, transform.position.z);
        // if (transform.position.y < -8.5f)
        //     transform.position = new Vector3(transform.position.x, -8.5f, transform.position.z);
        // if (transform.position.y > 8.5f)
        //     transform.position = new Vector3(transform.position.x, 8.5f, transform.position.z);
            
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

    /// <summary>
    /// 主角受伤
    /// </summary>
    /// <param name="damage"></param>
    public void PlayerHurt(int damage)
    {
        
    }
    
}
