using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{

    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    NavMeshAgent agent;
    Animator animator;
    GameObject player;

    float timePassed;
    float newDestinationCD = 0.5f;
    public int CurrentHealth = 2;
    public int MaxHealth = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);
        
        if(timePassed >= attackCD)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
            {
                transform.LookAt(player.transform.position);
                animator.SetTrigger("attack");
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
        //transform.LookAt(player.transform);
    }
    

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

    // public void StartDealDamage()
    // {
    //     GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    // }

    // public void EndDealDamage()
    // {
    //     GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    // }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}