using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory Data")]
public class InventoryData_SO : ScriptableObject
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(ItemData_SO newItemData)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemData == null)
            {
                items[i].ItemData = newItemData;
                break;
            }
        }
    }
}

[System.Serializable]
public class InventoryItem
{
    public ItemData_SO ItemData;
}