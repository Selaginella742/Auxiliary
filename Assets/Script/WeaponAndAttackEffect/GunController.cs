using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet(5f);
    }

    void ShootBullet(float speed)
    {

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, transform.position,transform.rotation);
        }
    }
}
