using UnityEngine;

public class Blocker : MonoBehaviour
{

    public GameObject blocker;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider collision)
        {
            if(!collision.CompareTag("Player")) return;
            {
                blocker.SetActive(true);
            }
        }
    }
}
