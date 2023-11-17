using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathState : IState
{
    PlayerFSM fsm;
    GameObject player;
    float delay = 2.0f;

    public DeathState(PlayerFSM fsm, GameObject player)
    {
        this.fsm = fsm;
        this.player = player;
        delay = 2.0f;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnUpdate()
    {
        delay -= Time.deltaTime;
    }
}
