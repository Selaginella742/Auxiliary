using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType {BAG,WEAPON}
public class SlotHolder : MonoBehaviour
{
    public SlotType slotType;

    public ItemUI itemUI;

    public void UpdateItem()
    {
        switch (slotType)
        {
            case SlotType.BAG:
                itemUI.Bag = InventoryManager.Instance.inventoryData;
                break;
            case SlotType.WEAPON:
                break;
        }

        var item = itemUI.Bag.items[itemUI.Index];
        itemUI.SetupItemUI(item.ItemData);
    }
}
