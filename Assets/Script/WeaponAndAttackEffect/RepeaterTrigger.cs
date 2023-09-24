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
  
    // Start is called before the first frame update
    void Start()
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
            Instantiate(bullet, transform.position, transform.rotation);
            shootIndex--;

            Invoke("BulletShot", timeBetween);
        }
        else
            Destroy(this.gameObject);
    }
}
