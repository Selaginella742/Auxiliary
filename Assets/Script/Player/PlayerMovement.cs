using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed;
    CharacterData_SO playerData;

    float currentCool;
    //private Animator anim;
    private void Start()
    {
        playerData = this.gameObject.GetComponent<CharacterStats>().characterData;
        currentCool = playerData.currentDashCool;
    }

    void Update()
    {
        PlayerMovementController(playerData.currentSpeed);
        //PlayerMovementTranslate(playerData.currentSpeed);

        if (currentCool >= 0)
            currentCool -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentCool <= 0)
            {
                StartCoroutine(performDash());
                currentCool = playerData.currentDashCool;
            }
        }
    }


    void PlayerMovementTranslate(float speed) 
    {
        //get player's input
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0, vertical);

        //change the player movement into the isometric view (up, down, right, left direction in isometric view)
        var toIso = Matrix4x4.Rotate(Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0));
        var isoDir = toIso.MultiplyPoint3x4(direction).normalized;

        //change the player's rotation toward player movment
        if (isoDir != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(isoDir), rotateSpeed * Time.deltaTime);

        transform.position += isoDir * speed * Time.deltaTime;
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

        //change the player movement into the isometric view (up, down, right, left direction in isometric view)
        var toIso = Matrix4x4.Rotate(Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0));
        var isoDir = toIso.MultiplyPoint3x4(direction).normalized;

        //change the player's rotation toward player movment
        if (isoDir != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(isoDir), rotateSpeed*Time.deltaTime);

        GetComponent<CharacterController>().Move(isoDir * speed * Time.deltaTime);
    }

    IEnumerator performDash() 
    {
        playerData.currentSpeed += playerData.currentDashSpeed;

        yield return new WaitForSeconds(0.1f);

        playerData.currentSpeed -= playerData.currentDashSpeed;
    }

    public float GetCurrentCool() 
    {
        return currentCool;
    }
}
