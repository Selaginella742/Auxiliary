using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailStat : MonoBehaviour
{
    public CharacterData_SO playerStats;

    // Update is called once per frame
    void Update()
    {
        if (playerStats.currentHealth <= 0)
            SceneManager.LoadScene("Menu");

    }
}
