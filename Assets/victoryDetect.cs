using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryDetect : MonoBehaviour
{
    public GameObject winText;
    private bool win = false;

    void FixedUpdate()
    {
        Detect();
        Victory();
    }

    void Detect()
    {
        if (!win)
        {
            if (GameObject.Find("FinalBoss") == null)
            {
                win = true;
            }
        }
    }

    public void BacktoMenu()
    {
        if (win)
            SceneManager.LoadScene("Menu");
    }

    void Victory()
    {
        if (win)
        {
            winText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
