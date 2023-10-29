using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireTrap : MonoBehaviour
{
    public float turnInterval;
    public float onTime;
    private float realtimeInterval;
    private float realonTime;
    private bool isOn;
    public GameObject trap;

    void FixedUpdate()
    {
        Switch();
    }

    void Start()
    {
        realtimeInterval = turnInterval;
        realonTime = onTime;
    }
    void TurnON()
    {
        realtimeInterval -= Time.deltaTime;
        if (realtimeInterval <= 0)
        {
            trap.SetActive(true);
            isOn = true;
            realtimeInterval = turnInterval;
        }
    }

    void TurnOFF()
    {
        realonTime -= Time.deltaTime;
        if (realonTime <= 0)
        {
            trap.SetActive(false);
            isOn = false;
            realonTime = onTime;
        }
    }

    void Switch()
    {
        if (isOn == false)
            TurnON();
        else 
            TurnOFF();
    }
}
