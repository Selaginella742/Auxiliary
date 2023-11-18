using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerUI : MonoBehaviour
{
    public SlotHolder[] slotHolders;
    public int slotIndex;

    public void RefreshUI()
    {
        for (int i = 0; i < slotHolders.Length; i++)
        {
            slotHolders[i].itemUI.Index = i;
            slotHolders[i].UpdateItem();
        }
    }

    public void DeleteItem()
    {
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.maxHealth -= slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData.itemHealth;
        if (GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentHealth > GameObject.Find("Player").GetComponent<CharacterStats>().characterData.maxHealth)
            GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentHealth = GameObject.Find("Player").GetComponent<CharacterStats>().characterData.maxHealth;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDefence -= slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData.itemDefence;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentSpeed -= slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData.itemSpeed;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDashSpeed -= slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData.itemDashSpeed;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDashCool += slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData.itemDashCool;

        slotHolders[slotIndex].itemUI.Bag.items[slotIndex].amount = 0;
        slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData = null;
        slotHolders[slotIndex].itemUI.SetupItemUI(null, 0);
    }

}
