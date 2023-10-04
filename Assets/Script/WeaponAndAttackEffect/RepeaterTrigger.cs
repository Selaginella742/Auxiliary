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
    [HideInInspector]
    public IWeapon repeater;

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

            if (repeaterData.shootSound != null)
                AudioSource.PlayClipAtPoint(repeaterData.shootSound, Camera.main.transform.position, 0.5f);

            repeater.MuzzleFlash();

            GameObject shot = Instantiate(repeaterData.bulletPrefab, transform.position, transform.rotation);
            IBullet shotData = shot.GetComponent<IBullet>();
            shotData.affectDamage = repeaterData.CurrentDamage();
            shotData.launchSource = LaunchSource.player;
            shootIndex--;

            Invoke("BulletShot", timeBetween);
        }
        else
            this.gameObject.SetActive(false);
    }
}
