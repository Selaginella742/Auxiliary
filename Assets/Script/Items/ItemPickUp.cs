using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public ItemData_SO itemData;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO:put item into inventory
            InventoryManager.Instance.inventoryData.AddItem(itemData,itemData.itemAmount);
            InventoryManager.Instance.inventoryUI.RefreshUI();

            ItemAffectOnPlayer();
            Destroy(gameObject);
        }    
    }

    void ItemAffectOnPlayer()
    {
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.maxHealth += itemData.itemHealth;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentHealth += itemData.itemHealth;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDefence += itemData.itemDefence;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentSpeed += itemData.itemSpeed;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDashSpeed += itemData.itemDashSpeed;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDashCool -= itemData.itemDashCool;
    }
}
