using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject fallingE;
    private Animation animation;
    public float attackInterval;
    private float currentInterval;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        currentInterval = attackInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FinalBossMovement();
        ShootFalling();
    }

    private void FinalBossMovement()
    {
        if (transform.position.z >= -340)
        {
            Vector3 newPosition = transform.position;
            newPosition.z -= 0.1f;
            transform.position = newPosition;
        }
    }

    private void ShootFalling()
    {
        currentInterval -= Time.deltaTime;
        if (currentInterval <= 0)
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 fallingEP = new Vector3(playerPosition.x, 50, playerPosition.z);
            animation.Play();
            Instantiate(fallingE, fallingEP, transform.rotation);
            currentInterval = attackInterval;
        }
    }

}
