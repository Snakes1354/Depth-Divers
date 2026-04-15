using NUnit.Framework.Interfaces;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private PlayerController playerController;

    void Start()
    {
        cam = GetComponent<PlayerController>().cam;
        playerUI = GetComponent<PlayerUI>();
        playerController = GetComponent<PlayerController>();
    }


    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (playerController.playerInput.Main.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }

    }
}