using UnityEngine;

public class MonsterHurtText : MonoBehaviour
{
    //动画事件，销毁text
    public void DestroyText()
    {
        Destroy(gameObject);
    }
}
