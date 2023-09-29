using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Image healthSlider;

    public CharacterStats characterStats;

    void Awake()
    {
        healthSlider = transform.GetChild(0).GetComponent<Image>();

    }

    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        float sliderPercent = (float)characterStats.CurrentHealth / characterStats.MaxHelath;
        healthSlider.fillAmount = sliderPercent;

        //Debug.Log(healthSlider.fillAmount);
    }
}
