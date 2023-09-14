using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed;
    public float existTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletMovement(speed);

        existTime -= Time.deltaTime;

        if (existTime <= 0) 
        {
            Destroy(bulletPrefab);
        }
    }

    void bulletMovement(float speed) 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
