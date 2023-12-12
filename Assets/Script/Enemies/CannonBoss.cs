using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBoss : MonoBehaviour
{
    public float interval;
    public int damage;
    public GameObject pointOne;
    public GameObject pointTwo;
    public GameObject gunModel;
    public GameObject shootEffect;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;
    private Animation animation;
    private float intervalRecord;
    private int count = 0;

    void Start()
    {
        intervalRecord = interval;
        animation = GetComponent<Animation>();
    }

    void CannonShoot()
    {
        intervalRecord -= Time.deltaTime;
        if (intervalRecord <= 0)
        {
            count += 1;
            animation.Play();
            intervalRecord = interval;
            if (count % 3 != 0)
            {
                GameObject effect = Instantiate(shootEffect, gunModel.transform.position + gunModel.transform.forward * 10, Quaternion.Euler(0, 270, 0));
                GameObject shot = Instantiate(bulletPrefab, pointOne.transform.position, transform.rotation);
                GameObject shot1 = Instantiate(bulletPrefab, pointTwo.transform.position, transform.rotation);
                var shotData = shot.GetComponent<IBullet>();
                var shotData1 = shot1.GetComponent<IBullet>();

                Destroy(effect, 0.2f);

                if (shotData != null)
                {
                    shotData.launchSource = LaunchSource.enemy;
                    shotData.affectDamage = damage;
                    shotData.speed = 100;
                }

                if (shotData1 != null)
                {
                    shotData1.launchSource = LaunchSource.enemy;
                    shotData1.affectDamage = damage;
                    shotData1.speed = 100;
                }
            }

            else
            {
                GameObject effect = Instantiate(shootEffect, gunModel.transform.position + gunModel.transform.forward * 10, Quaternion.Euler(0, 270, 0));
                GameObject shot = Instantiate(bulletPrefab1, pointOne.transform.position, transform.rotation);
                GameObject shot1 = Instantiate(bulletPrefab1, pointTwo.transform.position, transform.rotation);
                var shotData = shot.GetComponent<IBullet>();
                var shotData1 = shot1.GetComponent<IBullet>();

                Destroy(effect, 0.2f);

                if (shotData != null)
                {
                    shotData.launchSource = LaunchSource.enemy;
                    shotData.affectDamage = damage * 2;
                    shotData.speed = 100;
                }

                if (shotData1 != null)
                {
                    shotData1.launchSource = LaunchSource.enemy;
                    shotData1.affectDamage = damage * 2;
                    shotData1.speed = 100;
                }
            }
        }
    }


    private void FixedUpdate()
    {
        CannonShoot();
    }
}
