using UnityEngine;

public class ChestOpen : Interactable
{
    public GameObject chestui;
    public CanvasGroup ChestCanvas;

    protected override void Interact()
    {
        chestui.SetActive(true);
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        promptMessage = "";
        Time.timeScale = 0f;
        ChestCanvas.alpha = 1;
    }

//      public void UpdateDamage()
//    {
//      statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatManager.Instance.damage;
//      // Sets one of my text to damage and when clicked calls the statmanager damage variable to show how much your damage stat is
//    }
}