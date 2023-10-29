using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBag : MonoBehaviour

{
    public GameObject myBag;
    public GameObject player;

    void Update()
    {
        OpenTheBag();
    }

    void OpenTheBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!myBag.activeSelf)
            {
                myBag.SetActive(true);
                player.GetComponent<PlayerFSM>().SwitchState(StateType.ShowingInfo);

            }

            else if (myBag.activeSelf)
            {
                myBag.SetActive(false);
                player.GetComponent<PlayerFSM>().SwitchState(StateType.Walking);
            }
        }
    }


}
