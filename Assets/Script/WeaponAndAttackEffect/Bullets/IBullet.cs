using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaunchSource {none, enemy, player}

public abstract class IBullet : MonoBehaviour
{
    public float speed;
    public float existTime;
    public GameObject bulletEffect;
    private GameObject bulletSound;

    [Header("Monitoring Realtime Bullet Data")]
    [ReadOnly] public LaunchSource launchSource;
    [ReadOnly] public int affectDamage;
    [ReadOnly] public float affectSpeed;
    [ReadOnly] public float affectTime;
    [ReadOnly] public float impulse;


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
        bulletSound = Instantiate(bulletEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(bulletSound,1.0f);


        if (coli.gameObject.tag == "Enemy" && launchSource == LaunchSource.player)
            effectOnCharacter(coli);
        else if(coli.gameObject.tag == "Player" && launchSource == LaunchSource.enemy)
            effectOnCharacter(coli);
    }
    protected abstract void effectOnCharacter(Collision coli);
}
