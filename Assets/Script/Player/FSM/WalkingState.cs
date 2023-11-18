using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class WalkingState : IState
{
    PlayerFSM fsm;
    GameObject player;

    CharacterController playerControl;
    PlayerMovement playerMovement;
    PlayerRotation playerRotation;

    public WalkingState(PlayerFSM fsm, GameObject player)
    {
        this.fsm = fsm;
        this.player = player;

        playerControl = player.GetComponent<CharacterController>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerRotation = player.GetComponent<PlayerRotation>();

    }

    /**
     * activate player's movement scripts
     */
    public void OnEnter()
    {
        playerControl.enabled = true;
        playerMovement.enabled = true;
        playerRotation.enabled = true;
    }

    /**
     * deactivate player's movement scripts
     */
    public void OnExit()
    {
        playerMovement.enabled = false;
        playerRotation.enabled = false;
        playerControl.enabled = false;
    }

    public void OnUpdate()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") ==0)// check if there is input for moving, if so, play walking animation
        {
            player.GetComponentInChildren<Animator>().SetBool("Walk", false);
        }

        else
        {
            player.GetComponentInChildren<Animator>().SetBool("Walk", true);
        }



    }
}
