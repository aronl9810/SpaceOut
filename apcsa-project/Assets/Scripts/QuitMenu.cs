using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class QuitMenu : MonoBehaviour
{

    private string finalTime;
    public TextMeshProUGUI timerText;

    void Update(){
        // Debug.Log(TimerScript.stringtimer);
        finalTime = TimerScript.stringtimer;
        // Debug.Log(finalTime);
        timerText.text = finalTime;
    }

    public void Play()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
