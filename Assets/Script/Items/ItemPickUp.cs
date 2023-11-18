using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public ItemData_SO[] itemDatas;
    private ItemData_SO itemData;

    void RandomItem()
    {
        itemData = itemDatas[Random.Range(0, itemDatas.Length)];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO:put item into inventory
            RandomItem();
            InventoryManager.Instance.AddItemToInventory(itemData);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("ItemPickUp");

        }
    }
}
