using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyHand : IWeapon
{
    protected override void AttackMode(){ }

    protected override void Start()
    {
        damageData.UpdateData();
        currentCooldown = damageData.buffedCooldown;
    }

    protected override void Update(){ }
}
