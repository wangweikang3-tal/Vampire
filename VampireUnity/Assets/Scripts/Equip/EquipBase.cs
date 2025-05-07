using System;
using System.Collections;
using Equip;
using UnityEngine;

public class EquipBase : MonoBehaviour
{
    [NonSerialized]public Rigidbody2D equipRb;
   [NonSerialized] public int equipID; // 装备ID
   [NonSerialized]public string equipName;//装备名字
   [NonSerialized]public FightEquipAttribute EquipAttributes; // 装备属性
    [NonSerialized]public float speed = 5f; // 装备跟随的速度
    [NonSerialized]public bool isPickUp = false; // 是否被拾取
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EquipBase(int equipID,string equipName,FightEquipAttribute equipAttribute)
    {
        this.equipID = equipID;
        this.equipName = equipName;
        this.EquipAttributes = equipAttribute;
    }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            isPickUp= true;
        }else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, GameController.S.gamePlayer.transform.position, Time.deltaTime * speed);
    }
}
