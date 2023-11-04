using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class WalkingState : IState
{
    PlayerFSM fsm;
    GameObject player;

    public WalkingState(PlayerFSM fsm, GameObject player)
    {
        this.fsm = fsm;
        this.player = player;
    }

    public void OnEnter()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerRotation>().enabled = true;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        
    }
}
