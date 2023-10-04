using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Image image;
    Transform pos;
    GameObject canvas;
    void Start()
    {
        canvas = GameObject.Find("WeaponDropCanvas");
        GameObject icon = Instantiate(image, canvas.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
