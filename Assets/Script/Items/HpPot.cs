using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPot : MonoBehaviour
{   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterStats>().characterData.currentHealth += 20;
            if (other.GetComponent<CharacterStats>().characterData.currentHealth > other.GetComponent<CharacterStats>().characterData.maxHealth)
                other.GetComponent<CharacterStats>().characterData.currentHealth = other.GetComponent<CharacterStats>().characterData.maxHealth;
            Destroy(gameObject);
        }
    }
}
