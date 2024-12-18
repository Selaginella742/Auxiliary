using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : IBullet
{

    protected override void effectOnCharacter(Collision coli)
    {
        CharacterStats enemyStats = coli.gameObject.GetComponent<CharacterStats>();
        if (enemyStats != null)
        {
            enemyStats.TakeDamage(affectDamage, enemyStats);
        }
    }
}
