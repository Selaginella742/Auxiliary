using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    public ItemData_SO[] itemDatas;
    private ItemData_SO itemData;

    void RandomItem()
    {
        itemData = itemDatas[Random.Range(0, itemDatas.Length)];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO:put item into inventory
            RandomItem();
            InventoryManager.Instance.AddItemToInventory(itemData);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("ItemPickUp");

            GameObject itemDisplay = GameObject.Find("Tutorial");
            if (itemDisplay != null)
            {
                var anim = itemDisplay.GetComponent<PlayableDirector>();

                anim.Stop();
                itemDisplay.GetComponentInChildren<Text>().text = itemData.itemName + " picked";
                anim.Play();
            }   

        }

        BulletType typeDisplay;
        GameObject.Find("BulletType").TryGetComponent<BulletType>(out typeDisplay);
        if (typeDisplay != null)
        {
            typeDisplay.DetectBulletType();
        }

    }
}
