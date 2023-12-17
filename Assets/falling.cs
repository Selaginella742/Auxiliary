using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    private CharacterStats health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Falling();
    }

    void Falling()
    {
        if (transform.position.y > 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= 0.8f;
            transform.position = newPosition;
        }

        if (transform.position.y <= 0)
        {
            health.characterData.currentHealth = 0;
        }
    }
}
