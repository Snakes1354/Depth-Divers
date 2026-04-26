using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class StatsUI : MonoBehaviour
{

  public CanvasGroup chestCanvas;
  public GameObject[] statsSlots; // Makes it so you have to assign a gameobject in the inspector
  public CanvasGroup statsCanvas; // Makes it so you have to assign a canvas in the inspector

  // VARIABLES
  private bool statsOpen = false;
  public static int Points;

    private void Update()
    {
      if(Input.GetButtonDown("ToggleStats")) // Makes it so when you press a curtain button it opens togglestats
      {
        if(statsOpen) // This if statement only works if statsopen bool is true
          {
            Cursor.visible = false; // Sets my cursor visiblity to false
            Cursor.lockState = CursorLockMode.Locked; // This locks my cursor
            Time.timeScale = 1; // Pauses the time in the game
            statsCanvas.alpha = 0; // Makes the canvas invisible

            if (chestCanvas != null)
            {
              chestCanvas.blocksRaycasts = true;
              chestCanvas.interactable = true;
            }

            statsOpen = false; // Sets the statsopen bool to false

          }
          else
          {
            Cursor.visible = true; // Sets my cursor visiblity to true
            Cursor.lockState = CursorLockMode.None; // This Unlocks my cursor
            Time.timeScale = 0; // This unpauses the time in the game
            statsCanvas.alpha = 1; // Makes the canvas seeable

            if (chestCanvas != null)
            {
              chestCanvas.blocksRaycasts = false;
              chestCanvas.interactable = false;
            }

            statsOpen = true; // Sets the statsopen bool to true
          }
      }
      UpdateAllStats(); // Calls updateallstats method
      
    }

   public void UpdateDamage()
   {
     statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatManager.Instance.damage;
     // Sets one of my text to damage and when clicked calls the statmanager damage variable to show how much your damage stat is
   }

   public void UpdateSpeed()
   {
     statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatManager.Instance.MovementSpeed;
     // Sets one of my text to damage and when clicked calls the statmanager speed variable to show how much your speed stat is
   }

   public void Updatehealth()
   {
     statsSlots[2].GetComponentInChildren<TMP_Text>().text = "MaxHealth: " + PlayerStats.Instance.maxHealth;
     // Sets one of my text to damage and when clicked calls the statmanager maxhealth variable to show how much your maxhealth stat is
   }

   public void Updatepoints()
   {
     statsSlots[3].GetComponentInChildren<TMP_Text>().text = "Points: " + Points;
     // This line is used to update how many point you have
   }

   public void UpdateAllStats()
   {
        UpdateDamage(); // Calls the updatedamage method
        UpdateSpeed(); // Calls the updatespeed method
        Updatehealth(); // Calls the updatehealth method
        Updatepoints(); // Calls the updatepoints method
   }

}