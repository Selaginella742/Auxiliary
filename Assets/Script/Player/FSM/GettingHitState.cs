using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHitState : IState
{
    PlayerFSM fsm;
    GameObject player;

    public GettingHitState(PlayerFSM fsm, GameObject player) 
    {
        this.fsm = fsm;
        this.player = player;
    }

    public void OnEnter()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;

        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void OnExit()
    {
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void OnUpdate()
    {
    }
}
