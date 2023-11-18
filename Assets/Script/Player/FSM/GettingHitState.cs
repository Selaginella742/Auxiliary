using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHitState : IState
{
    PlayerFSM fsm;
    GameObject player;

    Rigidbody rb;
    CapsuleCollider collider;

    public GettingHitState(PlayerFSM fsm, GameObject player) 
    {
        this.fsm = fsm;
        this.player = player;

        rb = player.GetComponent<Rigidbody>();
        collider = player.GetComponent<CapsuleCollider>();
        
    }
    /**
     * activate rigidbody's physics simulation
     */
    public void OnEnter()
    {
        rb.detectCollisions = true;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        collider.enabled = true;

    }

    /**
     * deactivate rigidbody's physics simulation
     */
    public void OnExit()
    {
        rb.detectCollisions = false;
        rb.isKinematic = true;
        collider.enabled = false;
    }

    public void OnUpdate()
    {
    }
}
