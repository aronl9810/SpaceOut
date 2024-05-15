using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    private bool gameStarted;
    private float timer;
    public static string stringtimer;
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;   
        stringtimer = "Head over to the red lever to start the game";
        timerText.text = stringtimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted){
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
            stringtimer = "" + minutes.ToString ("00") + ":" + seconds.ToString ("00") + "." + milliseconds.ToString("00") + "";
            timerText.text = stringtimer;

        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("time", stringtimer);
    }

    public void startTimer(){
        gameStarted = true;
    }

    public string killed(){
        gameStarted = false;
        return stringtimer;
    }

    public string returnTimer(){
        return stringtimer;
    }



}
