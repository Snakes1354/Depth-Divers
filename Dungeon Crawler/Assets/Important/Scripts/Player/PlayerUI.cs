using UnityEngine;
using TMPro;
using System.Runtime.Serialization;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI promptText; // Makes it so you can assign the text in the inspector

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage; // Makes it so you can change the promptmessage in the inspector
    }
}