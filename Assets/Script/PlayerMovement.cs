using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

    /**
     * control player's movement using the transform component
     * */
    void PlayerMovementTranslate(float speed) 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.forward * vertical * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * horizontal * speed *Time.deltaTime);
        }
    }

    /**
     * control the player's movement using the Character Controller component
     * */
    void PlayerMovementController(float speed) 
    {
        //get player's input
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0, vertical);

        var toIso = Matrix4x4.Rotate(Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0));
        var isoDir = toIso.MultiplyPoint3x4(direction);

        GetComponent<CharacterController>().Move(isoDir * speed * Time.deltaTime);
    }
}
