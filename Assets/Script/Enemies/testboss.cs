using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testboss : MonoBehaviour
{
    public GameObject portal;
    void Update()
    {
        if (GameObject.Find("testboss") == null)
        {
            Debug.Log("Boss Killed!");
            portal.SetActive(true);
        }
    }
}
