using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    public WeaponList_SO weaponList;
    CharacterData_SO playerData;

    GameObject[] weapons; // the weapons in the weapon holder
    int weaponIndex;

    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerData = player.GetComponent<CharacterStats>().characterData;

        weapons = new GameObject[weaponList.weaponList.Count];
        for (int i = 0; i < weaponList.weaponList.Count; i++)
        {
            GameObject weapon = Instantiate(weaponList.weaponList[i], transform); // create all weapons in the weaponlist
            weapon.SetActive(false);
            weapons[i] = weapon;
            
        }

        weapons[weaponIndex].SetActive(true);
    }

    void Update()
    {
        int newWeapon = weaponIndex;

        if (this.gameObject.name == "RightWeaponHolder")//check if is  right hand or left hand, and read the corresponding index
            newWeapon = playerData.rightWeaponIndex;
        else if (this.gameObject.name == "LeftWeaponHolder")
            newWeapon = playerData.leftWeaponIndex;
        
        if (newWeapon != weaponIndex)
            SwitchWeapon(newWeapon);
    }
    /**
     * This method switch the player's current weapon based on the 
     * input index represented the id of the weapon
     */
    void SwitchWeapon(int newIndex) 
    {
        weapons[weaponIndex].SetActive(false);

        for (int i = 0; i < weapons.Length; i++)// find the weapon with that input index
            if (i == newIndex)
            {
                weapons[i].SetActive(true);
                break;
            }
        weaponIndex = newIndex;
    }
}
