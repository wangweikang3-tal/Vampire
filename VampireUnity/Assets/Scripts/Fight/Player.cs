using UnityEngine;

public class Player : MonoBehaviour
{

    private int _playerSpeed = 5;
    // Update is called once per frame
    void Update()
    {
        //获得输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //移动角色
        transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * _playerSpeed);
    }
    public void SetSpeed(int speed)
    {
        _playerSpeed = speed;
    }
}
