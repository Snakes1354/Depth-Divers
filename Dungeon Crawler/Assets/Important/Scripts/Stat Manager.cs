using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;

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
        Destroy(gameObject);
    }
}
