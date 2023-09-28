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

    [TextArea]
    public string description = "";
}
