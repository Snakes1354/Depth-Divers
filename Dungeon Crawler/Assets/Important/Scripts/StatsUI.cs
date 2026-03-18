using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class StatsUI : MonoBehaviour
{
   public GameObject[] statsSlots;
   public CanvasGroup statsCanvas;

   private bool statsOpen = false;

    private void Update()
    {
        if(Input.GetButtonDown("ToggleStats"))
        if(statsOpen)
        {
            Time.timeScale = 1;
            statsCanvas.alpha = 0;
            statsOpen = false;
        }
        else
        {
            Time.timeScale = 0;
            statsCanvas.alpha = 1;
            statsOpen = true;
        }

        UpdateAllStats();

    }

   public void UpdateDamage()
   {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatManager.Instance.damage;
   }

   public void UpdateSpeed()
   {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatManager.Instance.MovementSpeed;
   }

   public void Updatehealth()
   {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "Health: " + StatManager.Instance.MaxHealth;
   }

   public void UpdateAllStats()
   {
        UpdateDamage();
        UpdateSpeed();
        Updatehealth();
   }
}
