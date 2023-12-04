using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerUI : MonoBehaviour
{
    public SlotHolder[] slotHolders;
    public int slotIndex;

    public void RefreshUI()
    {
        for (int i = 0; i < slotHolders.Length; i++)
        {
            slotHolders[i].itemUI.Index = i;
            slotHolders[i].UpdateItem();
        }
    }

    public void DeleteItem()
    {
        CharacterStats playerData = GameObject.Find("Player").GetComponent<CharacterStats>();
        slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData.DeleteEffectOnPlayer(playerData);//ִ��item data���Ƴ�Ч���ĺ���

        slotHolders[slotIndex].itemUI.Bag.items[slotIndex].amount = 0;
        slotHolders[slotIndex].itemUI.Bag.items[slotIndex].ItemData = null;
        slotHolders[slotIndex].itemUI.SetupItemUI(null, 0);
    }

}
