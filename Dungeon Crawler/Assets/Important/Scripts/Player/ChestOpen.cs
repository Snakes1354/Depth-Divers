using UnityEngine;

public class ChestOpen : Interactable
{
    public GameObject chestui;

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        chestui.SetActive(true);
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        promptMessage = "";
        Time.timeScale = 0f;
    }
}