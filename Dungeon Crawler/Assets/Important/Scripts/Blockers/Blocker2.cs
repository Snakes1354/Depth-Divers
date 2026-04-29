using UnityEngine;

public class Blocker2 : MonoBehaviour
{

    public GameObject blocker2;

    void OnTriggerEnter(Collider collision)
    {
        if(!collision.CompareTag("Player")) return;
        {
            blocker2.SetActive(true);
        }
    }
    
}