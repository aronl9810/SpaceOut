using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerMotor getPlayerMotor;
    public AudioSource audioSource;


    // Update is called once per frame
    void Update()
    {
        if(getPlayerMotor.getSprint()){
            audioSource.pitch = 1.25f;
        } else {
            audioSource.pitch = 0.75f;
        }
    }
}
