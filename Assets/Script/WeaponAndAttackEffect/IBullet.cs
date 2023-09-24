using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBullet : MonoBehaviour
{
    public float speed;
    public float existTime;

    public float affectSpeed;
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
}
