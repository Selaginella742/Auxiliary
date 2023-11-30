using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public PlayerFSM State;

    // Update is called once per frame
    void Update()
    {
        // Hit escape to pause/resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume ()
    {
        //Stop time and pull up menu
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        State.SwitchState(StateType.Walking);


        GamePaused = false;
    }
    void Pause ()
    {
        //Close menu and resume time
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        State.SwitchState(StateType.ShowingInfo);
 
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
