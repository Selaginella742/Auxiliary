using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    private Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FinalBossMovement();
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

}
