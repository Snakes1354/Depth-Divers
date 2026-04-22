using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{

    // VARIABLES
    [SerializeField] private float attackCD = 3f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float aggroRange = 4f;
    [SerializeField] private int CurrentHealth = 2;
    [SerializeField] private int MaxHealth = 3;
    [SerializeField] private int ExpAmount;
    private float timePassed;
    private float newDestinationCD = 0.5f;

    [Header("Assign in inspector")]
    NavMeshAgent agent;
    Animator animator;
    GameObject player;

    private void Start()
    {
        animator = GetComponent<Animator>(); // Finds where the animator component is
        agent = GetComponent<NavMeshAgent>(); // Finds where the agent component is
        player = GameObject.FindWithTag("Player"); // Find where the gameobject player with the tag player is
    }

    private void Update()
    {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed); // Enables the float speed in the animator controller
        
        if(timePassed >= attackCD) // Checks if the cooldown is over
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
            {
                transform.LookAt(player.transform.position); // Looks at the player
                animator.SetTrigger("attack"); // Changes the animaton to attack
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
            ExpManager.Instance.AddExperience(ExpAmount);
            // Call Death method when it hits 0 hp.
        }
    }

    void Death()
    {
        Destroy(gameObject);
        KillManager.PrintEnemyCount();
        // Death function
        // Temporary: Destroy Object
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}