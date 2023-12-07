using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
   public int damage;


    void OnTriggerEnter(Collider other)
    {
        CharacterStats target = other.gameObject.GetComponent<CharacterStats>();
        if (target != null&&other.CompareTag("Player"))
        {
            target.TakeDamage(damage, target);
        }

        else if (target !=null&&other.CompareTag("Enemy"))
        {
            target.TakeDamage(damage * 10, target);
        }
    }
    
}
