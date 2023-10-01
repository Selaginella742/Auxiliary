using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotationMouse();
    }

    void PlayerRotationMouse() 
    {
        var dirRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(dirRay, out hit, Mathf.Infinity, LayerMask.GetMask("ground")))
        {

            var deltaPos = hit.point - transform.position;
            var angle = Mathf.Atan2(deltaPos.x, deltaPos.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
