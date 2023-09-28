using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data")]
public class CharacterData_SO : ScriptableObject
{
    [Header("Stats Info")]
    public int maxHealth;
    public int baseDefence;
    public float baseSpeed;

    [Header("Player only")]
    public float baseDashCool;
    public float dashSpeed;

    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int currentDefence;
    [HideInInspector]
    public float currentSpeed;
    [HideInInspector]
    public float currentDashCool;
    [HideInInspector]
    public float currentDashSpeed;

    [Header("Weapon System")]
    [Tooltip("This controls which weapon the player is carrying at the left hand")]
    [Range(0, 1)]
    public int leftWeaponIndex;
    [Tooltip("This controls which weapon the player is carrying at the right hand")]
    [Range(0, 1)]
    public int rightWeaponIndex;
    
}
