using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CompleteLevel : MonoBehaviour
{
    [SerializeField] public GameObject SuccessScreenUI;
    public PauseMenu Pause;
    public static bool GamePaused = false;
    public PlayerFSM State;
    public static bool BossKilled = false;
    void Update()
    {
        if (GameObject.Find("testboss") == null)
        {
            Debug.Log("Boss Killed!");
            SuccessAchieved();
        }
    }

    public void SuccessAchieved()
    {
        //Close menu and resume time
        SuccessScreenUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GamePaused = true;
        State.SwitchState(StateType.ShowingInfo);
    }
    public void NextLevel()
    {
        SuccessScreenUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GamePaused = false;
        Debug.Log("Next Level!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        State.SwitchState(StateType.Walking);

    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}

