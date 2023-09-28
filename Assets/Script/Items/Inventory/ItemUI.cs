using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image icon = null;

    public InventoryData_SO Bag { get; set; }

    public int Index { get; set; } = -1;

    public void SetupItemUI(ItemData_SO item)
    {
        if (item != null)
        {
            icon.sprite = item.itemIcon;
            icon.gameObject.SetActive(true);
        }
        else
            icon.gameObject.SetActive(false);
    }
}
