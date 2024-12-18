using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image icon = null;

    public Text amount = null;

    public InventoryData_SO Bag { get; set; }

    public int Index { get; set; } = -1;

    public void SetupItemUI(ItemData_SO item, int ItemAmount)
    {
        if (item != null)
        {
            icon.sprite = item.itemIcon;
            //amount.text = ItemAmount.ToString();
            icon.gameObject.SetActive(true);
        }
        else
            icon.gameObject.SetActive(false);
    }

    public ItemData_SO GetItem()
    {
        return Bag.items[Index].ItemData;
    }
}
