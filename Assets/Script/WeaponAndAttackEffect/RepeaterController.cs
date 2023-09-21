using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterController : IWeapon
{
    [Header("Repeater Varibles")]
    [Tooltip("This varible controls how many bullets will be launched in one cooldown turn")]
    public int bulletCount;
    [Tooltip("This variable controls the time interval of each bullet in one cooldown turn")]
    public float shootingInterval = 0.2f;

    private float shootingTime;//when will the bullet be shot

    protected override void Start()
    {
        currentCooldown = shootingInterval * bulletCount;
        launchPos = transform.position;
        launchDir = transform.rotation;

        shootingTime = shootingInterval * bulletCount;
    }

    protected override void Attack()
    {
        Debug.Log(currentCooldown);
        if (Input.GetMouseButton(handPos))
        {
            if (currentCooldown <= shootingTime)
            {
                AttackMode();
                Debug.Log("bullet launch");
                shootingTime -= shootingInterval;
            }
        }
    }

    public override void CalculateCooldown(float reduceAmount)
    {
        if (currentCooldown >= shootingTime)
            currentCooldown -= reduceAmount;

        if (currentCooldown <= 0)
        {
            shootingTime = shootingInterval * bulletCount;
            currentCooldown = weaponCooldown;
        }
    }
    protected override void AttackMode() 
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
