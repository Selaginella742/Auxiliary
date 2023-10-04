using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterTrigger : MonoBehaviour
{
    [HideInInspector]
    public GameObject bullet;
    [HideInInspector]
    public int shootIndex; // control how many bullets are shot in one turn
    [HideInInspector]
    public float timeBetween; // control the time between each shot
    [HideInInspector]
    public WeaponData repeaterData;
  
    void OnEnable()
    {
        BulletShot();
    }

    /**
     * This method shoot a bullet and recursively call itself until it finishes one shooting turn
     */
    void BulletShot() 
    {
        if (shootIndex > 0)
        {
            GameObject shot = Instantiate(bullet, transform.position, transform.rotation);
            IBullet shotData = shot.GetComponent<IBullet>();
            shotData.affectDamage = repeaterData.buffedDamage;
            shotData.launchSource = LaunchSource.player;
            shootIndex--;

            Invoke("BulletShot", timeBetween);
        }
        else
            this.gameObject.SetActive(false);
    }
}
