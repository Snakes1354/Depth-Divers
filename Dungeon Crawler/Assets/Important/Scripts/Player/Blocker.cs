using UnityEngine;

public class Blocker : MonoBehaviour
{

    public GameObject blocker;

    void OnTriggerEnter(Collider collision)
    {
        if(!collision.CompareTag("Player")) return;
        {
            blocker.SetActive(true);
        }
    }
    
}
