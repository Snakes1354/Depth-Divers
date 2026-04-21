using UnityEngine;

public class KillManager : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Wall1;
   // public GameObject Wall2;
   // public GameObject Wall3;
   // public GameObject Wall4;

    public static int TotalEnemiesDefeated = 0;

    public static void PrintEnemyCount()
    {
        Debug.Log($"Enemies defeated: {TotalEnemiesDefeated}");
    }

    private void Update()
    {
        DestroyWall();
        DestroyWall1();
    }

    public void DestroyWall()
    {
        if (TotalEnemiesDefeated >= 1)
        {
            Destroy(Wall);
        }
    }

    public void DestroyWall1()
    {
        if (TotalEnemiesDefeated >= 3)
        {
            Destroy(Wall1);
        }
    }
}