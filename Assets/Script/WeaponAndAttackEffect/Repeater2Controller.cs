using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Repeater2Controller : IWeapon
{
    GameObject repeaterTrigger;

    [Header("Repeater Attributes")]
    [Tooltip("This controls how many bullets will be shot in one turn")]
    [Min(0)]
    public int bulletAmount;
    [Tooltip("This controls the time between each shot")]
    [Min(0)]
    public float timeBetweenShot;

    protected override void Start()
    {
        base.Start();
        repeaterTrigger = Resources.Load<GameObject>("Prefabs/RepeaterTrigger");//load the trigger(the prefab to control multiply shot)
    }
    protected override void AttackMode() 
    {
        var repeaterIns = Instantiate(repeaterTrigger, transform);
        var repeaterTrig = repeaterIns.GetComponent<RepeaterTrigger>();

        repeaterTrig.bullet = bulletPrefab;
        repeaterTrig.timeBetween = timeBetweenShot;
        repeaterTrig.shootIndex = bulletAmount;
    }
}
