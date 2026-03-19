using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class StatsUI : MonoBehaviour
{

   public GameObject[] statsSlots;
   public CanvasGroup statsCanvas;

    private bool statsOpen = false;
    public static int Points;

    private void Update()
    {
        if(Input.GetButtonDown("ToggleStats"))
        if(statsOpen)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            statsCanvas.alpha = 0;
            statsOpen = false;
        }
        else
        {
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
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
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "MaxHealth: " + StatManager.Instance.MaxHealth;
   }

   public void Updatepoints()
   {
        statsSlots[3].GetComponentInChildren<TMP_Text>().text = "Points: " + Points;
   }

   public void UpdateAllStats()
   {
        UpdateDamage();
        UpdateSpeed();
        Updatehealth();
        Updatepoints();
   }

}
