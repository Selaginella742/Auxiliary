using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Player Status Item")]
public class Item_Stats_SO : ItemData_SO
{
    [Header("Item Data Affect On Player")]

    public int itemHealth;

    public int itemDefence;

    public float itemSpeed;

    public float itemDashCool;

    public float itemDashSpeed;

    /**
     * Use this function when the item is added to the inventory
     */
    public override void ApplyEffectOnPlayer(CharacterStats playerData)
    {
        playerData.characterData.maxHealth += itemHealth;
        playerData.characterData.currentHealth += itemHealth;
        playerData.characterData.currentDefence += itemDefence;
        playerData.characterData.currentSpeed += itemSpeed;
        playerData.characterData.currentDashCool += itemDashCool;

    }

    /**
     * Use this function when the item is deleted from the inventory
     */
    public override void DeleteEffectOnPlayer(CharacterStats playerData)
    {
        playerData.characterData.maxHealth -= itemHealth;
        if (playerData.characterData.currentHealth > itemHealth)
        {
            playerData.characterData.currentHealth -= itemHealth;
        }
        playerData.characterData.currentDefence -= itemDefence;
        playerData.characterData.currentSpeed -= itemSpeed;
        playerData.characterData.currentDashCool -= itemDashCool;
    }
}
