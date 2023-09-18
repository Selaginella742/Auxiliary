using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class GunController : IWeapon
{

    protected override void AttackMode() 
    {
        Instantiate(bulletPrefab, launchPos, launchDir);
    }
}
