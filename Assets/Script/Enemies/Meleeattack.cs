using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeattack : MonoBehaviour
{
    private CharacterStats characterStats;
    private int attack;

    void Start()
    {
        characterStats = GetComponentInParent<CharacterStats>();
        attack = characterStats.attackData.damage;
    }

    void OnTriggerEnter(Collider other)
    {
        CharacterStats target = other.gameObject.GetComponent<CharacterStats>();
        if (target != null)
        {
            target.TakeDamage(attack, target);
        }
    }
}
