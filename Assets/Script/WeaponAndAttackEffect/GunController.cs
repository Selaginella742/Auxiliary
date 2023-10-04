using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunController : IWeapon
{

    protected override void AttackMode() 
    {
        if (damageData.shootSound != null)
            AudioSource.PlayClipAtPoint(damageData.shootSound, Camera.main.transform.position, 5f);

        GameObject shot = Instantiate(damageData.bulletPrefab, launchPos, launchDir);
        IBullet shotData = shot.GetComponent<IBullet>();

        shotData.affectDamage = damageData.CurrentDamage();
        shotData.launchSource = LaunchSource.player;
        shotData.speed = damageData.buffedBulletSpeed;
    }
}
