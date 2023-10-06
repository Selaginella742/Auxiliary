using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Image healthSlider;

    public CharacterStats characterStats;

    void Awake()
    {
        characterStats.characterData.maxHealth = 100;
        characterStats.characterData.baseSpeed = 10;
        healthSlider = transform.GetChild(0).GetComponent<Image>();

    }

    void Update()
    {
        UpdateHealth();
        if (characterStats.characterData.currentHealth <= 0)
            SceneManager.LoadScene("Menu");
    }

    void UpdateHealth()
    {
        float sliderPercent = (float)characterStats.CurrentHealth / characterStats.MaxHelath;
        healthSlider.fillAmount = sliderPercent;

        //Debug.Log(healthSlider.fillAmount);
    }
}
