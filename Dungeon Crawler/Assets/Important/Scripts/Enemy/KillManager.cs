using UnityEngine;

public class KillManager : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;

    public static int TotalEnemiesDefeated = 0;

    public static void PrintEnemyCount()
    {
        Debug.Log($"Enemies defeated: {TotalEnemiesDefeated}");
        TotalEnemiesDefeated++;
    }

    private void Update()
    {
        DestroyWall();
        DestroyWall1();
        DestroyWall2();
        DestroyWall3();
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
        if (TotalEnemiesDefeated >= 4)
        {
            Destroy(Wall1);
        }
    }

    public void DestroyWall2()
    {
        if (TotalEnemiesDefeated >= 10)
        {
            Destroy(Wall2);
        }
    }

    public void DestroyWall3()
    {
        if (TotalEnemiesDefeated >= 12)
        {
            Destroy(Wall3);
        }
    }
}