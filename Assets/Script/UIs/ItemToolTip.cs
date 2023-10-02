using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    public Text itemName;
    public Text itemAmount;
    public Text itemDescription;

    public void SetupTooltip(ItemData_SO item)
    {
        itemName.text = item.itemName;
        itemAmount.text = item.itemAmount.ToString();
        itemDescription.text = item.description;
    }
}
