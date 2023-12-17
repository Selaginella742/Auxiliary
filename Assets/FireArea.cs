using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    public int damage;
    private float interval = 1.0f;
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interval -= Time.deltaTime;
            if (interval <= 0) 
            {
                CharacterStats target = other.GetComponent<CharacterStats>();
                target.TakeDamage(damage, target); 
                interval = 1.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interval = 1.0f;
    }
}
