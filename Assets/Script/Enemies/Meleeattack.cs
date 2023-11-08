using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeattack : MonoBehaviour
{
    private CharacterStats characterStats;
    private int attack;
    private Collider collider;

    void Start()
    {
        characterStats = GetComponentInParent<CharacterStats>();
        attack = characterStats.attackData.damage;
        collider = GetComponentInParent<Collider>();
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
