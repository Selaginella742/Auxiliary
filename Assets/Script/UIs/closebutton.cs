using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closebutton : MonoBehaviour
{
    public GameObject player;

    public void OnButtonPress()
    {
        Debug.Log("OnClick");
        player.GetComponent<PlayerFSM>().SwitchState(StateType.Walking);
    }
}
