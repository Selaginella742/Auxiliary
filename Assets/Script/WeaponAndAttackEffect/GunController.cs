using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class GunController : IWeapon
{

    protected override void AttackMode() 
    {
        GameObject shot = Instantiate(bulletPrefab, launchPos, launchDir);
        IBullet shotData = shot.GetComponent<IBullet>();

        shotData.affectDamage = damageData.CurrentDamage();
        shotData.launchSource = LaunchSource.player;
    }
}
