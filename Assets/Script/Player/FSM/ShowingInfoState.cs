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
        Time.timeScale = 0.0f;
        Cursor.visible = true;

    }

    public void OnExit()
    {
        Time.timeScale = 1.0f;

        Cursor.visible = false;
    }

    public void OnUpdate()
    {

    }
}
