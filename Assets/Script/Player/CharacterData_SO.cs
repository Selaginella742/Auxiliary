using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data")]
public class CharacterData_SO : ScriptableObject
{
    [Header("Stats Info")]
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;
    public int baseDefence;
    [HideInInspector]
    public int currentDefence;
    public int baseSpeed;
    [HideInInspector]
    public int currentSpeed;

    [Header("Player only")]
    public int baseDashCool;
    [HideInInspector]
    public int currentDashCool;

    [Tooltip("This controls which weapon the player is carrying at the left hand")]
    [Range(0, 1)]
    public int leftWeaponIndex;
    [Tooltip("This controls which weapon the player is carrying at the right hand")]
    [Range(0, 1)]
    public int rightWeaponIndex;

}
