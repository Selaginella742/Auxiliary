using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GameObject upperBody;
    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRotationMouse();
    }

    void PlayerRotationMouse() 
    {
        // control the player's facing direction
        var playerScreenPos = Camera.main.WorldToScreenPoint(transform.position); // get the player's postion at camera 
        var distance = Input.mousePosition - playerScreenPos; // get the distance difference between the mouse and the player
        var angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg; // calculate the angle between the player and the mouse in the world space
        var correctAngle = angle - 45;  //Camera.main.transform.rotation.y;

        //Debug.Log(Camera.main.transform.rotation.y);
        upperBody.transform.rotation = Quaternion.Euler(0,correctAngle,0);
    }
}
