using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum WeaponType {bullet, ray, meele};

public abstract class IWeapon : MonoBehaviour
{
    public WeaponType weaponType;

    [Tooltip("prefab for bullet type weapon, if some weapon need to instantiate a prefab, put it here, otherwise leave it empty")]
    public GameObject bulletPrefab;

    [Header("Weapon Variables")]
    [Min(0f)]
    public float weaponCooldown;
    public int weaponDamage;
    public float criticalMultiplier;
    public float criticalChance;

    protected bool isCritical;
    protected float buffedDamage; //store the current damage after the buff of items or the character
    protected float currentCooldown;
    protected Vector3 launchPos;
    protected Quaternion launchDir;
    protected int handPos; //determine right or left hand, right for 1 and left for 0

    protected void Awake() 
    {
        if (transform.parent.parent.gameObject.name == "RightWeaponHolder")// check if the weapon is at left hand or right hand
            handPos = 1;
        else if (transform.parent.parent.gameObject.name == "LeftWeaponHolder")
            handPos = 0;
        else
            handPos = 2;
    }
    protected virtual void Start()
    {
        currentCooldown = 0;
        launchPos = transform.position;
        launchDir = transform.rotation;
    }
    protected virtual void FixedUpdate()
    {

       CalculateCooldown(Time.deltaTime);
       UpdateDamage();
       UpdateLocation();

        Attack();
    }

    /**
     * update the attack loacation and direction
     */
    protected virtual void UpdateLocation()
    {
        launchPos = transform.position;
        launchDir = transform.rotation;

    }

    /**
     * calculate the current cooldown of the weapon
     */
    public virtual void CalculateCooldown(float reduceAmount) 
    {
        if (currentCooldown >= 0)
            currentCooldown -= reduceAmount;
    }

    /**
     * This method read the player's input and check if the weapon is ready to attack
     */
    protected virtual void Attack()
    {
        if (Input.GetMouseButton(handPos))
            if (currentCooldown <= 0)
            {
                AttackMode();
                currentCooldown = weaponCooldown;
            }
    }

    protected virtual void UpdateDamage() 
    {
        buffedDamage = weaponDamage;
    }

    /**
     * calculate the damage and if the current shot cause critical damage
     */
    protected int CurrentDamage(float inputDamage)
    {
        float coreDamage = inputDamage;

        if (isCritical)
        {
            coreDamage *= criticalMultiplier;
            Debug.Log("±©»÷£¡" + coreDamage);
        }
        return (int)coreDamage;
    }

    /**
     * The function of the weapon
     */
    protected abstract void AttackMode();

}
