using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public string playerdataName;
    public string inventorydataName;
    public string attackdataName;
    private CharacterData_SO playerData;
    private InventoryData_SO inventoryData;
    private AttackData_SO attackData;
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
        attackData = GameObject.Find("Player").GetComponent<CharacterStats>().attackData;
        Load(playerData, playerdataName);
        Load(inventoryData, inventorydataName);
        Load(attackData, attackdataName);
        GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>().inventoryUI.RefreshUI();
        Destroy(gameObject);
    }
}
