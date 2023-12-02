using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunController : IWeapon
{
    [Header("Minigun Variables")]
    [Tooltip("This variable controls the time interval between each damge")]
    public float damageInterval;

    float currentInterval = 0;

    protected override void Update()
    {
        UpdateLocation();
        damageData.UpdateData();

        if (currentCooldown <= 0)
        {
            overheat = false;
        }

        Attack();
    }

    protected override void Attack()
    {
        if (!overheat)
        {
            if (Input.GetMouseButton(handPos))
            {

                currentCooldown += Time.deltaTime; // 攻击的时候叠加积热槽

                if (currentCooldown >= damageData.buffedCooldown)
                {
                    overheat = true;

                }

                currentInterval -= Time.deltaTime; // 计算伤害间隔cd

                if (currentInterval <= 0)
                {
                    AttackMode();
                    currentInterval = damageInterval;
                }
            }
        }
        if (!Input.GetMouseButton(handPos) || overheat)
        {
            CalculateCooldown(Time.deltaTime); // 不攻击时减少积热槽
        }
    }
    protected override void AttackMode()
    {
        if (damageData.shootSound != null)
            AudioSource.PlayClipAtPoint(damageData.shootSound, Camera.main.transform.position, 0.5f);

        if (effectIns != null)
            MuzzleFlash();

        GameObject shot = Instantiate(damageData.bulletPrefab, launchPos, launchDir);
        IBullet shotData = shot.GetComponent<IBullet>();

        shotData.affectDamage = damageData.CurrentDamage();
        shotData.launchSource = LaunchSource.player;
        shotData.speed = damageData.buffedBulletSpeed;
    }
}
