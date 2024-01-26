using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Add or remove an interaction event component to this game object. 
    public bool useEvents;
    // Msg displayed to player when looking at interactable
    public string promptMessage;

    // This function will be called from our player
    public void BaseInteract(){
        if(useEvents){
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact(){
        // No code is written in this function. It is going to get overwritten by subclasses.
    }
}
