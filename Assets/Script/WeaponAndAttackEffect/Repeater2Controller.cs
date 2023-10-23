using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Repeater2Controller : IWeapon
{
    GameObject repeaterTrigger;
    GameObject triggerIns;

    [Header("Repeater Attributes")]
    [Tooltip("This controls how many bullets will be shot in one turn")]
    [Min(0)]
    public int bulletAmount;
    [Tooltip("This controls the time between each shot")]
    [Min(0.01f)]
    public float timeBetweenShot;

    private int shootIndex;

    protected override void Start()
    {
        base.Start();

        shootIndex = 0;
    }
    protected override void AttackMode() 
    {
        shootIndex = bulletAmount;

        BulletShot();
    }

    /**
     * This method shoot a bullet and recursively call itself until it finishes one shooting turn
     */
    void BulletShot()
    {
        if (shootIndex > 0)
        {

            if (damageData.shootSound != null)
                AudioSource.PlayClipAtPoint(damageData.shootSound, Camera.main.transform.position, 0.5f);

            MuzzleFlash();

            GameObject shot = Instantiate(damageData.bulletPrefab, transform.position, transform.rotation);
            IBullet shotData = shot.GetComponent<IBullet>();
            shotData.affectDamage = damageData.CurrentDamage();
            shotData.launchSource = LaunchSource.player;
            shootIndex--;

            Invoke("BulletShot", timeBetweenShot);
        }
    }
}
