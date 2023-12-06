using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotgunBullet : IBullet
{
    [Header("shotgun bullet variables")]
    [Tooltip("This variable controls the damage increase in the closest range")]
    public int maximumIncrease = 15;
    [Tooltip("This variable controls the maximum range of the increased damage")]
    [Min(0)]
    public float range = 150f;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    protected override void effectOnCharacter(Collision coli)
    {
        CharacterStats enemyStats = coli.gameObject.GetComponent<CharacterStats>();
        if (enemyStats != null)
        {

            enemyStats.TakeDamage(CalculateDamage(coli, affectDamage), enemyStats);
        }
    }

    /**
     * This function calculate the final damage of each shotgun bullet.
     *    - The closer the enemies are to the launch position, the more damage bullet do to them.
     *    - Deal double damage to enemies facing away from the bullet.
     */
    private int CalculateDamage(Collision coli, int damage) 
    {
        int resultDamage = damage;

        //calculate the range percent to the maximun effect range
        var rangePercent = Mathf.Max(0, 1 - (Vector3.Distance(startPos, transform.position) / range));
        resultDamage += (int)(maximumIncrease * rangePercent);

        // calculate the face angle between the bullet and the hitted enemy
        var angle = Vector3.Angle(transform.forward, coli.transform.forward);

        // if the angle is larger than 90, meaning the enemy is facing side or away from the bullet
        if (angle >= 90)
        {
            resultDamage *= 2;
        }

        return resultDamage;
    }
}
