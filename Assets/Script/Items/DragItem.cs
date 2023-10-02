using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemUI))]
public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    ItemUI currentItemUI;
    SlotHolder currentHolder;
    SlotHolder targetHolder;

    void Awake()
    {
        currentItemUI = GetComponent<ItemUI>();
        currentHolder = GetComponentInParent<SlotHolder>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        InventoryManager.Instance.currentDrag = new InventoryManager.DragData();
        InventoryManager.Instance.currentDrag.originalHolder = GetComponent<SlotHolder>();
        InventoryManager.Instance.currentDrag.originalParent = (RectTransform)transform.parent;
        //TODO:Record original data
        transform.SetParent(InventoryManager.Instance.dragCanvas.transform, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //TODO:Follow the mouse
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //TODO:Put down item and exchange data
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (InventoryManager.Instance.CheckInInventoryUI(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHolder>())
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>();
                }
                else
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();
                }
                //TODO:�ж��Ǳ������廹���������Ӷ��ŵ���ͬ�İ����
                switch (targetHolder.slotType)
                {
                    case SlotType.BAG:
                        SwapItem();
                        break;
                    case SlotType.WEAPON:
                        break;
                }

                currentHolder.UpdateItem();
                targetHolder.UpdateItem();
            }

        }

        else
        {
            Debug.Log("Item Dragged Outside of Inventory");
            
            DragOutItem();
            currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].amount = 0;
            currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].ItemData = null;
            currentHolder.itemUI.SetupItemUI(null, 0);
        }
        transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);

        RectTransform trans = transform as RectTransform;

        trans.offsetMax = -Vector2.one * 5;
        trans.offsetMin = Vector2.one * 5;
    }

    public void SwapItem()
    {
        var targetItem = targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index];
        var tempItem = currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index];

        currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index] = targetItem;
        targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index] = tempItem;
    }

    void DragOutItem()
    {
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.maxHealth -= currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].ItemData.itemHealth * currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].amount;
        if (GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentHealth > GameObject.Find("Player").GetComponent<CharacterStats>().characterData.maxHealth)
            GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentHealth = GameObject.Find("Player").GetComponent<CharacterStats>().characterData.maxHealth;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDefence -= currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].ItemData.itemDefence * currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].amount;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentSpeed -= currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].ItemData.itemSpeed * currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].amount;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDashSpeed -= currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].ItemData.itemDashSpeed * currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].amount;
        GameObject.Find("Player").GetComponent<CharacterStats>().characterData.currentDashCool += currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].ItemData.itemDashCool * currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].amount;
    }
}
