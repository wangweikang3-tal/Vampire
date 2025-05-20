using UnityEngine;

public class NormalAttack : MonoBehaviour
{
    public ParticleSystem trail;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            trail.gameObject.SetActive(false);
            other.transform.GetComponent<MonsterBase>().Hurt(50);
        }
    }
}
