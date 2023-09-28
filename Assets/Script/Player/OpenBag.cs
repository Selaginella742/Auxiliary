using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBag : MonoBehaviour

{
    public GameObject myBag;

    void Update()
    {
        OpenTheBag();
    }

    void OpenTheBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!myBag.activeSelf)
            {
                myBag.SetActive(true);
            }

            else if (myBag.activeSelf)
            {
                myBag.SetActive(false);
            }
        }
    }


}
