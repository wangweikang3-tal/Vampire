using System;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<MonsterBase>().Hurt(50);
        }
    }
}
