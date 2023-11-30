using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : IWeapon
{
    [SerializeField]GameObject line;

    LineRenderer lr;

    protected override void Start()
    {
        base.Start();
        lr = line.GetComponent<LineRenderer>();
    }
    protected override void Attack()
    {
        if (Input.GetMouseButton(handPos))
        {
            line.SetActive(true);

            Ray ray = new Ray(launchPos, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                lr.SetPosition(1, hit.point);
            }

            if (currentCooldown <= 0)
            {
                AttackMode();
                currentCooldown = damageData.buffedCooldown;
            }
        }
        else
        {
            line.SetActive(false);
        }
    }

    protected override void AttackMode() 
    {

        Ray ray = new Ray(launchPos, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject target = hit.transform.gameObject;
            
            if (target.tag == "Enemy") 
            {
                var targetStat = target.GetComponent<CharacterStats>();
                targetStat.TakeDamage(damageData.buffedDamage, targetStat);
            }
            
        }
    }
}
