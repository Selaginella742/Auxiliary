using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingInfoState : IState
{
    PlayerFSM fsm;
    GameObject player;

    public ShowingInfoState(PlayerFSM fsm, GameObject player)
    {
        this.fsm = fsm;
        this.player = player;
    }

    public void OnEnter()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerRotation>().enabled = false;

    }

    public void OnExit()
    {
;
    }

    public void OnUpdate()
    {

    }
}
