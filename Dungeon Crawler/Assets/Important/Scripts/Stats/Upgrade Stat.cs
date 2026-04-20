using UnityEngine;

public class UpgradeStat : MonoBehaviour
{
    public void UpdateDamage()
    {
        if (StatsUI.Points >= 1) // Checks to see if you have atleast one point
        {
            ChestOpen.Instance.initialDamage += 1;
            StatManager.Instance.damage += 1; // Goes to your statmanager script and adds + 1 to your damage variable
            StatsUI.Points -= 1; // Takes one point away from your statsui script
        }
    }

    public void UpdateSpeed()
    {
        if (StatsUI.Points >= 1) // Checks to see if you have atleast one point
        {
            ChestOpen.Instance.initialSpeed += 1;
            StatManager.Instance.MovementSpeed += 1; // Goes to your statmanager script and adds + 1 to your speed variable
            StatsUI.Points -= 1; // Takes one point away from your statsui scrip
        }
    }

    public void UpdateHealth()
    {
        if (StatsUI.Points >= 1) // Checks to see if you have atleast one point
        {
            PlayerStats.Instance.maxHealth += 10; // Goes to your statmanager script and adds + 10 to your maxhealth variable
            PlayerStats.Instance.currentHealth += 10; // Goes to your statmanager script and adds + 10 to your currenthealth variable
            ChestOpen.Instance.initialHealth += 10;
            PlayerStats.Instance.healthBar.SetSliderMax(PlayerStats.Instance.maxHealth); // Updates the slider max to make it so you can have more health
            PlayerStats.Instance.healthBar.SetSlider(PlayerStats.Instance.currentHealth); // Updates the currenthealth variable from the playerstats script
            StatsUI.Points -= 1; // Takes one point away from your statsui scrip
        }
    }
}
