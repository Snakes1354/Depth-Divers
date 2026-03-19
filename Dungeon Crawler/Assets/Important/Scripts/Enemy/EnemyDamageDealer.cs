using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDamageDealer : MonoBehaviour
{
    // bool canDealDamage;
    // bool hasDealtDamage;

    // [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    public static bool isAttacked = false;

    // void Start()
    // {
    //     canDealDamage = false;
    //     hasDealtDamage = false;
    // }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
           if (!isAttacked)
           {
                isAttacked = true;
                PlayerStats.Instance.TakeDamage(weaponDamage);
                Debug.Log("Help");
           }
        }
    }
    
    // public void StartDealDamage()
    // {
    //     canDealDamage = true;
    //     hasDealtDamage = false;
    //     Debug.Log("Enemy Dealt damage");
    // }
    // public void EndDealDamage()
    // {
    //     canDealDamage = false;
    // }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    // }
}