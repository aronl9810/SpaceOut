using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class finaltime : MonoBehaviour
{
    private string finalTime;
    public TextMeshProUGUI timerText;

    void Update()
    {
        Debug.Log("hi");
        TimerScript.stringtimer = finalTime;
        Debug.Log(finalTime);
        timerText.text = finalTime;
    }
}
