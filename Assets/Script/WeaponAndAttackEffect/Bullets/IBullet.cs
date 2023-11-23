using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaunchSource {none, enemy, player}

[RequireComponent(typeof(Rigidbody))]
public abstract class IBullet : MonoBehaviour
{
    public float speed = 30;
    public float existTime = 5;
    public GameObject bulletEffect;
    private GameObject bulletSound;
    public GameObject hitEffect;
    private GameObject hitIns;

    [Header("Monitoring Realtime Bullet Data")]
    [ReadOnly] public LaunchSource launchSource;
    [ReadOnly] public int affectDamage;
    [ReadOnly] public float affectSpeed;
    [ReadOnly] public float affectTime;
    [ReadOnly] public float impulse;


    void FixedUpdate()
    {
        bulletMovement(speed);
    }

    protected virtual void Update() 
    {
        existTime -= Time.deltaTime;

        if (existTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void bulletMovement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    protected virtual void OnCollisionEnter(Collision coli) 
    {
        print(coli.gameObject.layer);
        if (coli.gameObject.layer != 2) 
        {
            HitEffect();

            if (coli.gameObject.tag == "Enemy" && launchSource == LaunchSource.player)
                effectOnCharacter(coli);
            else if (coli.gameObject.tag == "Player" && launchSource == LaunchSource.enemy)
                effectOnCharacter(coli);

            HitReaction(coli); 
        }
    }
    protected abstract void effectOnCharacter(Collision coli);

    private void HitEffect() 
    {
        hitIns = Instantiate(hitEffect, transform.position, Quaternion.identity);// create the bullet hit effect
        Destroy(hitIns, 1.0f);

        bulletSound = Instantiate(bulletEffect, transform.position, Quaternion.identity);
        Destroy(bulletSound, 1.0f);
    }

    protected virtual void HitReaction(Collision coli) 
    {
        Destroy(this.gameObject);
    }
}
