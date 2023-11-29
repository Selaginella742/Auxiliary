using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : IWeapon
{
    [Range(0, 360)]
    public float launchAngle = 90f;

    public int bulletAmount = 3;

    protected override void AttackMode()
    {
        // calculate the first bullet's direction
        var bulletRot = Matrix4x4.Rotate(Quaternion.Euler(0, -(launchAngle/2), 0)).MultiplyPoint3x4(transform.forward);
        //calculate the angle matrix for changing each bullet's direction
        var launchStep = Matrix4x4.Rotate(Quaternion.Euler(0, launchAngle / bulletAmount, 0));


        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject shot = Instantiate(damageData.bulletPrefab, transform.position, Quaternion.LookRotation(bulletRot));

            IBullet shotData = shot.GetComponent<IBullet>();

            shotData.affectDamage = damageData.CurrentDamage();
            shotData.launchSource = LaunchSource.player;
            shotData.speed = damageData.buffedBulletSpeed;

            bulletRot = launchStep.MultiplyPoint3x4(bulletRot);
        }
    }
}