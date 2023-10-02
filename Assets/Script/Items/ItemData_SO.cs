using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType { Weapon,Passive}

[CreateAssetMenu(fileName ="New Item", menuName = "Item/Item Data")]
public class ItemData_SO : ScriptableObject
{
    public ItemType itemType;

    public string itemName;

    public Sprite itemIcon;

    public int itemAmount;

    public bool stackable;

    [TextArea]
    public string description = "";

    [Header("Item Data Affect On Player")]

    public int itemHealth;

    public int itemDefence;

    public float itemSpeed;

    public float itemDashCool;

    public float itemDashSpeed;
}
