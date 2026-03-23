using UnityEngine;

public class UpgradeStat : MonoBehaviour
{
    public void UpdateDamage()
    {
        if (StatsUI.Points >= 1)
        {
            StatManager.Instance.damage += 1;
            StatsUI.Points -= 1;
        }
    }

    public void UpdateSpeed()
    {
        if (StatsUI.Points >= 1)
        {
            StatManager.Instance.MovementSpeed += 1;
            StatsUI.Points -= 1;
        }
    }

    public void UpdateHealth()
    {
        if (StatsUI.Points >= 1)
        {
            PlayerStats.Instance.maxHealth += 10;
            PlayerStats.Instance.currentHealth += 10;
            StatsUI.Points -= 1;
        }
    }
}
