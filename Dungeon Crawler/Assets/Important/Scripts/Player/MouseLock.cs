using UnityEngine;

public class MouseLock : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
}
