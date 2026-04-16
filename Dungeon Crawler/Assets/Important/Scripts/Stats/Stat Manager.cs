using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    // I used a static so that my StatManager can be accessed from other scripts.

    [Header("Combat Stats")]
    public int damage;
    public float attackSpeed;

    [Header("Movement Stats")]
    public float MovementSpeed;


    private void Awake()
    {
        if(Instance == null)
        Instance = this;
        else
        Destroy(gameObject); // Destroys the gameobject
        // Makes it so that there can't be more than one StatManager in my game.
    }
}
