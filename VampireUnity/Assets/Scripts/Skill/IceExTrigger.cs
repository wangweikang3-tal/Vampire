using System;
using UnityEngine;

public class IceExTrigger : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Monster"))
      {
         other.GetComponent<MonsterBase>().Hurt(100);
      }
   }
}
