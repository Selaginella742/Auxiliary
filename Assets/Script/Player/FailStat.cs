using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailStat : MonoBehaviour
{
    public CharacterData_SO playerStats;
    public static bool GamePaused = false;
    [SerializeField] public GameObject GameOverMenuUI;
    public float restartDelay = 2f;
    // Update is called once per frame
    void Update()
    {
        if (playerStats.currentHealth <= 0)
        {
            Invoke("GameOver", restartDelay);
        }
           

    }
    void GameOver()
    {
        Debug.Log("Game Over!");
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void RestartLevel()
    {
        Debug.Log("Restart Level!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
