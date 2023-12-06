using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : IWeapon
{
    [Header("Ray Weapon Variables")]
    [Tooltip("This controls the line shown when the weapon attacks")]
    [SerializeField]GameObject line;
    [SerializeField] LineRenderer lr;
    [Tooltip("This variable controls the time interval between each damge")]
    public float damageInterval;
    public float maxDistance = 50;
    [SerializeField] AimingLine supportAiming;

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

                line.SetActive(true); // 攻击时显示射线

                currentCooldown += Time.deltaTime; // 攻击的时候叠加积热槽

                if (currentCooldown >= damageData.buffedCooldown)
                {
                    overheat = true;

                }

                Ray ray = new Ray(launchPos, transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, maxDistance))// 射线被物体遮挡
                {
                    lr.SetPosition(1, new Vector3(0, 0, hit.distance));
                }
                else 
                {
                    lr.SetPosition(1, new Vector3(0, 0, maxDistance));
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
            line.SetActive(false);
            CalculateCooldown(Time.deltaTime); // 不攻击时减少积热槽
        }
    }

    protected override void AttackMode() 
    {

        Ray ray = new Ray(launchPos, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            GameObject target = hit.transform.gameObject;
            
            if (target.tag == "Enemy") 
            {
                var targetStat = target.GetComponent<CharacterStats>();
                targetStat.TakeDamage(damageData.CurrentDamage(), targetStat);
            }
            
        }
    }
}
