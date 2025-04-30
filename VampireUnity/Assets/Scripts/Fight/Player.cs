using UnityEngine;

public class Player : MonoBehaviour
{

    private int _playerSpeed = 3;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerMoveAnimation();
    }

    private void PlayerMoveAnimation()
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
    
    private void PlayerMove()
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
}
