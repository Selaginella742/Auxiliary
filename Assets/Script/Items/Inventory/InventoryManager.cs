using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [Header("Inventory Data")]

    public InventoryData_SO inventoryData;

    [Header("Containers")]

    public ContainerUI inventoryUI;

    void Start()
    {
        inventoryUI.RefreshUI();
    }
}