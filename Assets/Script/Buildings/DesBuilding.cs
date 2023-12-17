using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterStats))]

public class DesBuilding : MonoBehaviour
{
    public bool isExplosion;
    private bool isBoom = false;
    private GameObject boomEffect;
    public GameObject explosionEffect;
    public GameObject hurtBox;
    private GameObject hurtArea;
    private CharacterStats characterStats;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        Destroyed();
    }

    void Destroyed()
    {
        if (characterStats.characterData.currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(gameObject, 0.2f);
            if (isExplosion && !isBoom)
            {
                isBoom = true;
                boomEffect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                hurtArea = Instantiate(hurtBox, transform.position, Quaternion.identity);
                Destroy(boomEffect, 2.0f);
                Destroy(hurtArea, 0.3f);
            }
        }
    }
}
