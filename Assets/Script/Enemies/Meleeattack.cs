using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeattack : MonoBehaviour
{
    bool isAttack;
    private Animator anim;
    private Collider collision;
    private CharacterStats characterStats;
    private int attack;
    void Start()
    {
        collision = GetComponent<Collider>();
        characterStats = GetComponentInParent<CharacterStats>();
        attack = characterStats.attackData.damage;
        anim = GetComponent<Animator>();
    }

    void OnAttack()
    {
        anim.SetBool("Attack", isAttack);
        collision.enabled = true;
    }

    void Update()
    {
        OnAttack();
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
