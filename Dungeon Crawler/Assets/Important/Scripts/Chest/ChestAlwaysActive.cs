using UnityEngine;

public class ChestAlwaysActive : MonoBehaviour
{
    public ChestOpen chestOpen;
    // Update is called once per frame
    void Update()
    {
       chestOpen.chestui.SetActive(true); 
    }
}
