using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL2BOSS : MonoBehaviour
{
    private CharacterStats characterStats;
    public GameObject Boss;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterStats.characterData.currentHealth <= 0)
        {
            Destroy(Boss);
        }
    }
}
