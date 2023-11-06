using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{

    Slider slider;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float currentPercent = player.GetComponent<PlayerMovement>().GetCurrentCool() / player.GetComponent<CharacterStats>().characterData.currentDashCool;

        slider.value = currentPercent;
    }
}
