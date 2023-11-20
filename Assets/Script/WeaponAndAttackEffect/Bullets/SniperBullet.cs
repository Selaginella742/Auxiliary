using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : IBullet
{
    [Tooltip("This variable controls the time interval of each damage increase")]
    public float damageDelay = 0.5f; // the cooldown for calculate the interval of adding damage
    [Tooltip("This variable controls the th amount of damage increase in each step")]
    public int damageIncreaseStep;
    [Tooltip("This variable controls the bounce frequency of the bullet")]
    public int bounce = 1;

    private void Update()
    {
        damageDelay -= Time.deltaTime;

        if (damageDelay <= 0)
        {
            affectDamage += damageIncreaseStep;
        }
    }

    protected override void OnCollisionEnter(Collision coli)
    {
        base.OnCollisionEnter(coli);

        var hitNormal = coli.GetContact(0).normal;

        if (coli.gameObject.layer == 9)
        {
            if (bounce > 0)
            {
                var reflect = Vector3.Reflect(transform.forward, hitNormal);// calculate the reflect angle
                transform.rotation = Quaternion.LookRotation(reflect);
                bounce--;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    protected override void effectOnCharacter(Collision coli)
    {
        CharacterStats enemyStats = coli.gameObject.GetComponent<CharacterStats>();
        if (enemyStats != null)
        {
            enemyStats.TakeDamage(affectDamage, enemyStats);
        }
    }
}
