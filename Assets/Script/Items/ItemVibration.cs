using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVibration : MonoBehaviour
{
    float sineCalc;
    Vector3 anchorPos;

    void Start()
    {
        sineCalc = 0f;
        anchorPos = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 currentAngle = transform.rotation.eulerAngles;
        currentAngle.y += 0.5f;
        transform.rotation = Quaternion.Euler(currentAngle);

        sineCalc += 0.05f;


        transform.position = new Vector3(anchorPos.x, anchorPos.y + Mathf.Sin(sineCalc), anchorPos.z);

        if (sineCalc >= Mathf.PI * 2)
            sineCalc = 0;
    }
}
