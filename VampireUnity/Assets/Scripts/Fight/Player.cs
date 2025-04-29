using UnityEngine;

public class Player : MonoBehaviour
{

    private int _playerSpeed = 5;
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
        Debug.Log("horizontal:" + horizontal);
        Debug.Log("vertical:" + vertical);
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //移动角色
        transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * _playerSpeed);
        if (horizontal < 0)
        {
            //翻转Sprite
            spriteRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    public void SetSpeed(int speed)
    {
        _playerSpeed = speed;
    }
}
