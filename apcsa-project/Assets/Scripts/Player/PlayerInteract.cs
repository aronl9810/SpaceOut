using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private ImageToggle imgToggle;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        imgToggle = GetComponent<ImageToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty); // This is to ensure that the UI will clear when you look away at the interactable
        // Create a ray at the center of the camera, shooting outwards.
        imgToggle.imageOn();
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // Variable to store collision information
        if (Physics.Raycast(ray, out hitInfo, distance, mask)){
            // Debug.Log("First Condition Passed");
            if(hitInfo.collider.GetComponent<Interactable>() != null){
                // Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                imgToggle.imageOff();
                if(inputManager.onFoot.Interact.triggered){
                    interactable.BaseInteract();
                }
            }
        }
    }
}
