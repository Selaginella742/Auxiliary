using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyBulletController: MonoBehaviour
{
    public float speed;
    public float existTime;
    private CharacterStats characterStats;

    
    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletMovement(speed);

        existTime -= Time.deltaTime;

        if (existTime <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

    void bulletMovement(float speed) 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        var etargetStats = other.GetComponent<CharacterStats>();
        

        if (other.CompareTag("Player"))
        {
            etargetStats.TakeDamage(characterStats, etargetStats);
            Destroy(gameObject);
        }

        if (other.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }


}
