using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotationMouse();
    }

    void PlayerRotationMouse() 
    {
        // control the player's facing direction
        var playerScreenPos = Camera.main.WorldToScreenPoint(transform.position); // get the player's postion at camera 
        var distance = Input.mousePosition - playerScreenPos; // get the distance difference between the mouse and the player
        var angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg; // calculate the angle between the player and the mouse in the world space

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle + Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
