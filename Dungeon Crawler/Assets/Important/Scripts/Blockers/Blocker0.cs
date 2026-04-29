using UnityEngine;

public class Blocker0 : MonoBehaviour
{

    public GameObject blocker0;

    void OnTriggerEnter(Collider collision)
    {
        if(!collision.CompareTag("Player")) return;
        {
            blocker0.SetActive(true);
        }
    }
    
}