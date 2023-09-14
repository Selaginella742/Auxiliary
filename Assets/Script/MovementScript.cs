using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMovementTranslate(5f);
        PlayerMovementController(5f);
    }

    // control player's movement using the transform component
    void PlayerMovementTranslate(float speed) 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * horizontal * speed *Time.deltaTime);
        }

        // control the player's facing direction
        var playerScreenPos = Camera.main.WorldToScreenPoint(transform.position); // get the player's postion at camera 
        var distance = Input.mousePosition - playerScreenPos; // get the distance difference between the mouse and the player
        var angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg; // calculate the angle between the player and the mouse in the world space

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle + Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
    }

    //control the player's movement using the Character Controller component
    void PlayerMovementController(float speed) 
    {
        //get player's input
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0, vertical);

        GetComponent<CharacterController>().Move(direction * speed * Time.deltaTime);
    }
}
