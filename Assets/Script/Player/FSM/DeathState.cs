using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathState : IState
{
    PlayerFSM fsm;
    GameObject player;

    public DeathState(PlayerFSM fsm, GameObject player)
    {
        this.fsm = fsm;
        this.player = player;
    }

    void IState.OnEnter()
    {
        
    }

    void IState.OnExit()
    {
        SceneManager.LoadScene("Menu");
    }

    void IState.OnUpdate()
    {
        
    }
}
