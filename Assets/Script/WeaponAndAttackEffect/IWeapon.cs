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

    public float weaponDamage;

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

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentCooldown = 0;
        launchPos = transform.position;
        launchDir = transform.rotation;

        //Debug.Log("handPos: " + handPos);
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {

       CalculateCooldown(Time.deltaTime);
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

        //var dirRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(dirRay, out hit, Mathf.Infinity, 3))
        //{
        //    var deltaPos = hit.point - transform.position;
        //    var angle = Mathf.Atan2(deltaPos.x, deltaPos.z) * Mathf.Rad2Deg;

        //    Debug.Log(angle);
        //    launchDir = Quaternion.Euler(0, angle, 0);
        //}
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

    /**
     * The function of the weapon
     */
    protected abstract void AttackMode();

}
