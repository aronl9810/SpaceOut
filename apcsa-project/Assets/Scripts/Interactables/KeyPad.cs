using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
   [SerializeField]     
    private GameObject door;
    [SerializeField]
    private TimerScript timerscript;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // This is where we design our interaction using code
    protected override void Interact(){
        // base.Interact();
        doorOpen = true;
        timerscript.startTimer();
        // Debug.Log(doorOpen);
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
        promptMessage = "Good luck!";
    }

    public bool gameStarted(){
        return doorOpen;
    }
}
