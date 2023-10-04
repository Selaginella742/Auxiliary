using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Repeater2Controller : IWeapon
{
    GameObject repeaterTrigger;
    GameObject triggerIns;

    [Header("Repeater Attributes")]
    [Tooltip("This controls how many bullets will be shot in one turn")]
    [Min(0)]
    public int bulletAmount;
    [Tooltip("This controls the time between each shot")]
    [Min(0.01f)]
    public float timeBetweenShot;

    protected override void Start()
    {
        base.Start();
        repeaterTrigger = Resources.Load<GameObject>("Prefabs/RepeaterTrigger");//load the trigger(the prefab to control multiply shot)
        triggerIns = Instantiate(repeaterTrigger, launchPos, launchDir, transform);
        triggerIns.SetActive(false);
    }
    protected override void AttackMode() 
    {
        var repeaterTrig = triggerIns.GetComponent<RepeaterTrigger>();

        repeaterTrig.timeBetween = timeBetweenShot;
        repeaterTrig.shootIndex = bulletAmount;
        repeaterTrig.repeaterData = damageData;
        repeaterTrig.repeater = this;

        triggerIns.SetActive(true);
    }
}
