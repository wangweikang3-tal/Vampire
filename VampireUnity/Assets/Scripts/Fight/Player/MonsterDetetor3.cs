using System;
using UnityEngine;

public class MonsterDetetor3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("进入触发器");
        //判断是否是怪物
        if (other.CompareTag("Monster"))
        {
            //获取怪物脚本
            MonsterBase monster = other.GetComponent<MonsterBase>();
            //Debug.Log(monster);
            //将怪物添加到队列中
            GameController.S.monsterDetetor3.Add(monster);
            //Debug.Log(GameController.Instance._monsterDetetor3.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("离开触发器");
        //判断是否是怪物
        if (other.CompareTag("Monster"))
        {
            //获取怪物脚本
            MonsterBase monster = other.GetComponent<MonsterBase>();
            //Debug.Log(monster);
            //将怪物从队列中移除
            GameController.S.monsterDetetor3.Remove(monster);
            //Debug.Log(GameController.Instance._monsterDetetor3.Count);
        }
    }
}
