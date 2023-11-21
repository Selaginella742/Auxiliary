using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : IBullet
{

    protected override void effectOnCharacter(Collision coli)
    {
        CharacterStats enemyStats = coli.gameObject.GetComponent<CharacterStats>();
        if (enemyStats != null)
        {
            enemyStats.TakeDamage(affectDamage, enemyStats);
        }
    }

    protected override void HitReaction(Collision coli)
    {
        var hitNormal = coli.GetContact(0).normal;

        if (coli.gameObject.layer == 9)
        {
            var reflect = Vector3.Reflect(transform.forward, hitNormal);// calculate the reflect angle
            transform.rotation = Quaternion.LookRotation(reflect);

        }
    }
}
