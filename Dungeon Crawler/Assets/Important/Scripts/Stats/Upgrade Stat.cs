using UnityEngine;
using TMPro;

public class UpgradeStat : MonoBehaviour
{
    public TMP_InputField AmountStats;

    public ChestOpen chestOpen;

    public void UpdateDamage()
    {
       if (int.TryParse(AmountStats.text, out int amount))
        {
            if (StatsUI.Points >= amount) // Checks to see if you have atleast one point
            {
                chestOpen.initialDamage += 1 * amount;
                StatManager.Instance.damage += 1 * amount;// Goes to your statmanager script and adds + 1 to your speed variable
                StatsUI.Points -= amount; 
            }
        }
    }

    public void UpdateSpeed()
    {
        if (int.TryParse(AmountStats.text, out int amount))
        {
            if (StatsUI.Points >= amount) // Checks to see if you have atleast one point
            {
                chestOpen.initialSpeed += 1 * amount;
                StatManager.Instance.MovementSpeed += 1 * amount;// Goes to your statmanager script and adds + 1 to your speed variable
                StatsUI.Points -= amount; 
            }
        }
    }

    public void UpdateHealth()
    {
        if (int.TryParse(AmountStats.text, out int amount))
        {
            if (StatsUI.Points >= amount) // Checks to see if you have atleast one point
            {
                PlayerStats.Instance.maxHealth += 10 * amount; // Goes to your statmanager script and adds + 10 to your maxhealth variable
                PlayerStats.Instance.currentHealth += 10 * amount; // Goes to your statmanager script and adds + 10 to your currenthealth variable
                chestOpen.initialHealth += 10 * amount;
                PlayerStats.Instance.healthBar.SetSliderMax(PlayerStats.Instance.maxHealth); // Updates the slider max to make it so you can have more health
                PlayerStats.Instance.healthBar.SetSlider(PlayerStats.Instance.currentHealth); // Updates the currenthealth variable from the playerstats script
                StatsUI.Points -= amount; 
            }
        }

    }
}
