using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public string playerdataName;
    public string inventorydataName;
    private CharacterData_SO playerData;
    private InventoryData_SO inventoryData;
    public void Load(Object data, string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), data);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerData = GameObject.Find("Player").GetComponent<CharacterStats>().characterData;
        inventoryData = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>().inventoryData;
        Load(playerData, playerdataName);
        Load(inventoryData, inventorydataName);
        GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>().inventoryUI.RefreshUI();
        Destroy(gameObject);
    }
}
