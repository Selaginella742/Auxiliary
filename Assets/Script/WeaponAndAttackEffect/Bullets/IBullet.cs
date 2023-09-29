using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaunchSource {enemy, player }

public abstract class IBullet : MonoBehaviour
{
    public float speed;
    public float existTime;

    public LaunchSource launchSource;
    public int affectDamage;
    public float affectSpeed;
    public float affectTime;
    public float impulse;


    // Update is called once per frame
    void FixedUpdate()
    {
        bulletMovement(speed);

        existTime -= Time.deltaTime;

        if (existTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void bulletMovement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter(Collision coli) 
    {
        Destroy(this.gameObject);


        if (coli.gameObject.tag == "Enemy")
            effectOnCharacter(coli);
    }
    protected abstract void effectOnCharacter(Collision coli);
}
