using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeattack : MonoBehaviour
{
    public GameObject hitPrefab;
    public GameObject attackSoundPrefab;
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
            GameObject hitIns = Instantiate(hitPrefab, transform.position, Quaternion.identity);
            Destroy(hitIns, 1.0f);
            GameObject hitSound = Instantiate(attackSoundPrefab, transform.position, Quaternion.identity);
            Destroy(hitSound, 1.0f);
        }
    }
}
