using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private int CurrentHealthTu = 2;
    [SerializeField] private int MaxHealthTu = 3;

    void Awake()
    {
        CurrentHealthTu = MaxHealthTu;
        // Sets hp at the start.
    }

    public void TakeDamage(int amountTu)
    {
        CurrentHealthTu -= amountTu;
        // Makes it take damage.

        if(CurrentHealthTu <= 0)
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
