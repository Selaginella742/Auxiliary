using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceToGame : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MenuMusic");
    }

    public void HitPlay ()
    {
        FindObjectOfType<AudioManager>().StopPlaying("MenuMusic");
        //FindObjectOfType<AudioManager>().Play("GameIntro");
 
        SceneManager.LoadScene("Main_Level");
        PauseMenu.GamePaused = false;
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
