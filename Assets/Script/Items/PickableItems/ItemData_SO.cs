using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType { Weapon,Passive}
public abstract class ItemData_SO : ScriptableObject
{
    public ItemType itemType;

    public string itemName;

    public Sprite itemIcon;

    public int itemAmount;

    public bool stackable;

    [TextArea]
    public string description = "";



    /**
     * Use this function when the item is added to the inventory
     */
    public abstract void ApplyEffectOnPlayer(CharacterStats playerData);

    /**
     * Use this function when the item is deleted from the inventory
     */
    public abstract void DeleteEffectOnPlayer(CharacterStats playerData);
}
