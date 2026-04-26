using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] float weaponDamage = 1f;

    float nextHitTime;

   void OnTriggerStay(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (Time.time < nextHitTime) return;

        nextHitTime = Time.time + 1f; 
        PlayerStats.Instance.TakeDamage(weaponDamage);
    }
}