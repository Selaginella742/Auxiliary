using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlotType {BAG,WEAPON}
public class SlotHolder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SlotType slotType;

    public ItemUI itemUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemUI.GetItem())
        {
            InventoryManager.Instance.tooltip.GetComponent<ItemToolTip>().SetupTooltip(itemUI.GetItem());
            InventoryManager.Instance.tooltip.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.tooltip.SetActive(false);
    }

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
        itemUI.SetupItemUI(item.ItemData, item.amount);
    }
}
