using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextLevel;
    public string playerdataName;
    public string inventorydataName;
    public string attackdataName;
    private CharacterData_SO playerData;
    private InventoryData_SO inventoryData;
    private AttackData_SO attackData;

    public void Save(Object data, string key)
    {
        var jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerData = GameObject.Find("Player").GetComponent<CharacterStats>().characterData;
        inventoryData = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>().inventoryData;
        attackData = GameObject.Find("Player").GetComponent<CharacterStats>().attackData;
        Save(playerData, playerdataName);
        Save(inventoryData, inventorydataName);
        Save(attackData, attackdataName);
        SceneManager.LoadScene(nextLevel);
    }
}
