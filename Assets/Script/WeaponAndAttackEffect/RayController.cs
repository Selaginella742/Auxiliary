using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : IWeapon
{
    GameObject line;

    protected override void Start()
    {
        base.Start();
        line = transform.GetChild(0).gameObject;
    }
    protected override void Attack()
    {
        if (Input.GetMouseButton(handPos))
        {
            if (currentCooldown <= 0)
            {
                line.SetActive(true);
                AttackMode();
                currentCooldown = weaponCooldown;
                //Debug.Log(line.GetComponent<LineRenderer>().GetPosition(1));
            }
        }
        else
        {
            line.SetActive(false);
        }
    }

    protected override void AttackMode() 
    {
        //Debug.Log("ray triggered");

        Ray ray = new Ray(launchPos, launchDir * Vector3.forward);
        RaycastHit hit;

        Debug.DrawRay(launchPos, launchDir * Vector3.forward, Color.green, 5f);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Object name: " + hit.transform.gameObject.name);
            Debug.Log(hit.transform.position);
            line.GetComponent<LineRenderer>().SetPosition(1, hit.transform.position);          
        }
    }
}
