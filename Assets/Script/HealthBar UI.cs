using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public GameObject healthUIprefab;

    public Transform barPoint;

    Image healthSlider;

    public bool shown;

    public float shownTime;

    Transform UIbar;

    Transform MainCamera;

    CharacterStats currenHealth;

    void Awake()
    {
        currenHealth = GetComponent<CharacterStats>();
        currenHealth.UpdateHealthBarOnTop += UpdateHealthBar;
    }

    void OnEnable()
    {
        MainCamera = Camera.main.transform;

        foreach (Canvas can in FindObjectsOfType<Canvas>())
        {
            if(can.renderMode == RenderMode.WorldSpace)
            {
                UIbar = Instantiate(healthUIprefab, can.transform).transform;
                healthSlider = UIbar.GetChild(0).GetComponent<Image>();
                UIbar.gameObject.SetActive(shown);
            }
        }
    }

    private void UpdateHealthBar(int health, int maxhealth)
    {
        if (health <= 0)
        {
            Destroy(UIbar.gameObject);
        }
        UIbar.gameObject.SetActive(true);

        float sliderPercent = (float)health / maxhealth;

        healthSlider.fillAmount = sliderPercent;
    }

    void LateUpdate()
    {
        if(UIbar != null)
        {
            UIbar.position = barPoint.position;
            UIbar.forward = -MainCamera.forward;
        }
    }
}
