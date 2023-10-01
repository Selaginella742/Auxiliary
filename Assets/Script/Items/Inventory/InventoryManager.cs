using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public class DragData
    {
        public SlotHolder originalHolder;

        public RectTransform originalParent;
    }

    [Header("Inventory Data")]

    public InventoryData_SO inventoryData;

    [Header("Containers")]

    public ContainerUI inventoryUI;

    [Header("Drag Canvas")]

    public Canvas dragCanvas;

    public DragData currentDrag;

    void Start()
    {
        inventoryUI.RefreshUI();
    }

    public bool CheckInInventoryUI(Vector3 position)
    {
        for (int i = 0;i < inventoryUI.slotHolders.Length;i++)
        {
            RectTransform trans = inventoryUI.slotHolders[i].transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(trans, position))
            {
                return true;
            }
        }
        return false;
    }


    
}