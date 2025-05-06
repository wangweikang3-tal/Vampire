using System.Collections;
using UnityEngine;

public class EquipBase : MonoBehaviour
{
    Rigidbody2D equipRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        equipRb=GetComponent<Rigidbody2D>();
        equipRb.velocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(3f, 5f));

        StartCoroutine(StopVelocityAfterDelay(equipRb, 0.75f));
    }

    // Update is called once per frame
    private IEnumerator StopVelocityAfterDelay(Rigidbody2D rb, float delay)
    {
        Debug.Log("协程启动");
        yield return new WaitForSeconds(delay);
        Debug.Log("等待结束");
        if(rb == null)
            Debug.Log("rb为空");
        rb.velocity = Vector2.zero;
        //设置重力为0
        rb.gravityScale = 0;
        Debug.Log("aaaaaaaaaaaaa");
    }
}
