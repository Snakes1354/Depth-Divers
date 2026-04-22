using UnityEngine;

public class AlwaysActive : MonoBehaviour
{
    public GameObject Chest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        Chest.SetActive(true);
    }
}
