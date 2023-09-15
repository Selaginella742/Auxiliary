using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // set a target to let camera follow
    public float smoothing = 5f; // how smooth camera movement would be
    Vector3 offset;

   
    void Start()
    {
        offset = transform.position - target.position; //set position
    }

    
    void LateUpdate() //update camera position
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
