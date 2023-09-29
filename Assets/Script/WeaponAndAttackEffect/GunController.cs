using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class GunController : IWeapon
{

    protected override void AttackMode() 
    {
        GameObject bullet = Instantiate(bulletPrefab, launchPos, launchDir);
        IBullet bulletEffect = bullet.GetComponent<IBullet>();

        bulletEffect.affectDamage = CurrentDamage(buffedDamage);
    }
}
