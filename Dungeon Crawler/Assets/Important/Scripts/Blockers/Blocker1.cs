using UnityEngine;

public class Blocker1 : MonoBehaviour
{

    public GameObject blocker1;
    public GameObject Gate;

    void OnTriggerEnter(Collider collision)
    {
        if(!collision.CompareTag("Player")) return;
        {
            Gate.SetActive(false);
            blocker1.SetActive(true);
        }
    }
    
}
