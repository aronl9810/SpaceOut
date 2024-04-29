using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("QuitMenu");
        Debug.Log("Player Has Quit The Game");
    }
}
