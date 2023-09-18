using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : IWeapon
{

    protected override void AttackMode() 
    {
        //Debug.Log("ray triggered");

        Ray ray = new Ray(launchPos, launchDir * Vector3.forward);
        RaycastHit hit;

        Debug.DrawRay(launchPos, launchDir * Vector3.forward, Color.green, 5f);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Object name: " + hit.transform.gameObject.name);
        }

    }
}
