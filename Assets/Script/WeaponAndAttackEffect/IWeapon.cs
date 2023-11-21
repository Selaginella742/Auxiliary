using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public enum WeaponType {bullet, ray, meele};

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

    protected void Awake() 
    {
        if (transform.parent.parent.gameObject.name == "RightWeaponHolder")// check if the weapon is at left hand or right hand
            handPos = 1;
        else if (transform.parent.parent.gameObject.name == "LeftWeaponHolder")
            handPos = 0;
        else
            handPos = 2;

        damageData.UpdateData();
    }
    protected virtual void Start()
    {
        
        currentCooldown = damageData.buffedCooldown;
        launchPos = transform.position;
        launchDir = transform.rotation;

        effectIns = Instantiate(damageData.shootEffect, launchPos, launchDir, transform);
        effectIns.SetActive(false);

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

    bool InteractWithUI()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else return false;
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

    [Tooltip("prefab for bullet type weapon, if some weapon need to instantiate a prefab, put it here, otherwise leave it empty")]
    public GameObject bulletPrefab;
    public AudioClip shootSound;
    public GameObject shootEffect;
    public Sprite icon;

    [Header("Damage Variables")]
    [Min(0f)]
    public float coolDown;
    public int damage;
    public float criticalMultiplier;
    public float criticalChance;
    public float bulletSpeed;

   

    [Header("Player Buffs Data")]
    [Tooltip("put player attack data here to calculate the buffed weapon data")]
    public AttackData_SO playerBuff;

    [Header("Monitoring weapon data")]
    [ReadOnly] public float buffedCooldown;
    [ReadOnly] public int buffedDamage;
    [ReadOnly] public bool isCritical;
    [ReadOnly] public float buffedCriticalChance;
    [ReadOnly] public float buffedCriticalMulti;
    [ReadOnly] public float buffedBulletSpeed;

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
        }
        else
        {
            buffedCooldown = coolDown;
            buffedDamage = damage;
            buffedCriticalChance = criticalChance;
            buffedCriticalMulti = criticalMultiplier;
            buffedBulletSpeed = bulletSpeed;
        }
    }
    /**
     * This method calculate weapon's critical shot damage
     */
    public int CurrentDamage()
    {
        float coreDamage = buffedDamage;

        if (isCritical)
        {
            coreDamage *= buffedCriticalMulti;
            Debug.Log("±©»÷£¡" + coreDamage);
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
}