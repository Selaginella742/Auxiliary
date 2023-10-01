using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaunchSource {none, enemy, player}

public abstract class IBullet : MonoBehaviour
{
    public float speed;
    public float existTime;

    [Header("Monitoring Realtime Bullet Data")]
    [ReadOnly] public LaunchSource launchSource;
    [ReadOnly] public int affectDamage;
    [ReadOnly] public float affectSpeed;
    [ReadOnly] public float affectTime;
    [ReadOnly] public float impulse;


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


        if (coli.gameObject.tag == "Enemy" && launchSource == LaunchSource.player)
            effectOnCharacter(coli);
        else if(coli.gameObject.tag == "Player" && launchSource == LaunchSource.enemy)
            effectOnCharacter(coli);
    }
    protected abstract void effectOnCharacter(Collision coli);
}
