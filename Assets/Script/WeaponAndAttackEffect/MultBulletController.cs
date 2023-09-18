using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultBulletController : IWeapon
{
    protected override void AttackMode() 
    {
        Instantiate(bulletPrefab, transform);
    }
}
