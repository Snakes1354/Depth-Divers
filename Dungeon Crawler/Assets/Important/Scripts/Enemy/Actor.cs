using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{

    public int CurrentHealth = 2;
    public int MaxHealth = 3;

    void Awake()
    {
        CurrentHealth = MaxHealth;
        // Sets hp at the start.
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        // Makes it take damage.

        if(CurrentHealth <= 0)
        {
            Death();
            ExpManager.Instance.AddExperience(5);
            // Call Death method when it hits 0 hp.
        }
    }

    void Death()
    {
        Destroy(gameObject);
        // Death function
        // Temporary: Destroy Object
    }
}