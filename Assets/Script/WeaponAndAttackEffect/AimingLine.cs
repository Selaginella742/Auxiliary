using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingLine : MonoBehaviour
{
    [Tooltip("This variable controls start position of the aiming line, please put the weapon's muzzle position here")]
    public GameObject aimingLine;
    [Tooltip("This variable controls how long does the aiming line have when it doesn't touch an object")]
    public float length;
    [Tooltip("This variable controls width of the line")]
    public float width;

    private Vector3[] nodes;
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        var al = GameObject.Instantiate(aimingLine,transform);
        lr = al.GetComponent<LineRenderer>();

        nodes = new Vector3[]{Vector3.forward * 0.1f, Vector3.forward * length };
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, length))
        {
            nodes[1] = Vector3.forward * hit.distance;
            lr.startColor = Color.red;
            lr.endColor = Color.red;
            lr.startWidth = width +0.1f;
            lr.endWidth = width + 0.1f;
        }
        else
        {
            nodes[1] = Vector3.forward * length;
            lr.startColor = Color.green;
            lr.endColor = Color.green;
            lr.startWidth = width;
            lr.endWidth = width;
        }

        lr.SetPositions(nodes);

    }
}
