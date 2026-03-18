using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;

    [Header("Combat Stats")]
    public int damage;
    public float attackSpeed;

    [Header("Movement Stats")]
    public float MovementSpeed;

    [Header("Health Stats")]
    public int MaxHealth;
    public int CurrentHealth;

    public int points;

    private void Awake()
    {
        if(Instance == null)
        Instance = this;
        else
        Destroy(gameObject);
    }
}
