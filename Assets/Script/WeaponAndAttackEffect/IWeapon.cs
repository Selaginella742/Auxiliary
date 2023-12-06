using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;

public enum WeaponType {bullet, heat};

public abstract class IWeapon : MonoBehaviour
{
    public WeaponType weaponType;

    [Header("Weapon Variables")]
    public WeaponData damageData;

    protected float currentCooldown;
    protected Vector3 launchPos;
    protected Quaternion launchDir;
    protected int handPos; //determine right or left hand, right for 1 and left for 0
    protected GameObject effectIns;

    protected bool overheat = false; // variables for heat weapons

    protected void Awake() 
    {
        if (transform.parent.parent.gameObject.name == "RightWeaponHolder")// check if the weapon is at left hand or right hand
            handPos = 1;
        else if (transform.parent.parent.gameObject.name == "LeftWeaponHolder")
            handPos = 0;
        else
            handPos = 2;

        damageData.SetPlayerBuff();
        damageData.UpdateData();
    }
    protected virtual void Start()
    {
        
        currentCooldown = damageData.buffedCooldown;
        launchPos = transform.position;
        launchDir = transform.rotation;

        effectIns = Instantiate(damageData.shootEffect, launchPos, launchDir, transform);
        effectIns.SetActive(false);

        currentCooldown = 0;
        overheat = false;

    }
    protected virtual void Update()
    {
        
        CalculateCooldown(Time.deltaTime);

        UpdateLocation();
        damageData.UpdateData();


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
                currentCooldown = damageData.buffedCooldown;
            }
    }

    public void MuzzleFlash()
    {
        effectIns.SetActive(true);
        Invoke("DisableFlash", 0.1f);
    }

    void DisableFlash()
    {
        effectIns.SetActive(false);
    }

    public float CheckCurrentCooldown() 
    {
        return currentCooldown;
    }

    /**
     * check if this weapon overheats.  If the weapon is a bullet weapon, it will always returns false
     */
    public bool CheckWeaponOverheat() 
    {
        if (weaponType == WeaponType.heat)
        {
            return overheat;
        }
        return false;
    }

    /**
     * The function of the weapon
     */
    protected abstract void AttackMode();

}

/**
 * This class represent the damage datas of the weapon
 */
[System.Serializable]
public class WeaponData
{

    [Tooltip("default bullet for bullet type weapon, if some weapon need to instantiate a prefab")]
    [SerializeField] GameObject defaultBulletPrefab;
    public AudioClip shootSound;
    public GameObject shootEffect;
    public Sprite icon;

    [Header("Damage Variables")]
    [Min(0f)]
    [SerializeField]float coolDown;
    [SerializeField] int damage;
    [Min(1.5f)]
    [SerializeField] float criticalMultiplier;
    [Range(0,1)]
    [SerializeField] float criticalChance;
    [SerializeField] float bulletSpeed;
    [Min(0.1f)]
    [SerializeField] float existTime;
    
    AttackData_SO playerBuff;
    

    [Header("Monitoring weapon data")]
    [ReadOnly] public GameObject bulletPrefab;
    [ReadOnly] public float buffedCooldown;
    [ReadOnly] public int buffedDamage;
    [ReadOnly] public bool isCritical;
    [ReadOnly] public float buffedCriticalChance;
    [ReadOnly] public float buffedCriticalMulti;
    [ReadOnly] public float buffedBulletSpeed;
    [ReadOnly] public float buffedExistTime;

    /**
     * This method update the weapon's damage data after the player get some damage buffs
     */
    public void UpdateData()
    {

        if (playerBuff != null)
        {
            buffedCooldown = playerBuff.coolDown + coolDown;
            buffedDamage = playerBuff.damage + damage;
            buffedCriticalChance = playerBuff.criticalChance + criticalChance;
            buffedCriticalMulti = playerBuff.criticalMultiplier + criticalMultiplier;
            buffedBulletSpeed = bulletSpeed;
            buffedExistTime = existTime;

            bulletPrefab = (playerBuff.bulletStack.Count != 0)? playerBuff.bulletStack[0] : defaultBulletPrefab;
        }
        else
        {
            buffedCooldown = coolDown;
            buffedDamage = damage;
            buffedCriticalChance = criticalChance;
            buffedCriticalMulti = criticalMultiplier;
            buffedBulletSpeed = bulletSpeed;
            buffedExistTime = existTime;
            bulletPrefab = defaultBulletPrefab;
        }
    }
    /**
     * This method calculate weapon's critical shot damage
     */
    public int CurrentDamage()
    {
        float coreDamage = buffedDamage;

        if (CheckCritical())
        {
            coreDamage *= buffedCriticalMulti;
        }
        return (int)coreDamage;
    }

    /**
     * This method determine if the weapon get a critical shot
     */
    public bool CheckCritical()
    {
        float critialLimit = UnityEngine.Random.value;

        if (critialLimit <= buffedCriticalChance)
            return true;

        return false;
    }

    public void SetPlayerBuff() 
    {
        playerBuff = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().attackData;
    }
}