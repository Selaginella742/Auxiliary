using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesBuilding : MonoBehaviour
{
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
            Destroy(gameObject);
    }
}
