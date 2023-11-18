using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public enum HandSide 
{
    Left,
    Right,
}

public class PlayerSwitchWeapon : MonoBehaviour
{
    public HandSide handSide;
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
            GameObject weapon = Instantiate(weaponList.weaponList[i].weapon, transform); // create all weapons in the weaponlist to the holder
            weapon.SetActive(false);
            weapon.GetComponentInChildren<IWeapon>().enabled = false;
            weapons[i] = weapon;
            
        }

        weapons[weaponIndex].SetActive(true);
        UpdateWeaponToStat();
    }

    void Update()
    {
        int newWeapon = weaponIndex;

        if (handSide == HandSide.Right)//check if is  right hand or left hand, and read the corresponding index
        {
            newWeapon = playerData.rightWeaponIndex;
        }
        else if (handSide == HandSide.Left)
        {
            newWeapon = playerData.leftWeaponIndex;
        }
        
        if (newWeapon != weaponIndex)
            StartCoroutine(SwitchWeapon(newWeapon));
    }
    /**
     * This method switch the player's current weapon based on the 
     * input index represented the id of the weapon
     */
    IEnumerator SwitchWeapon(int newIndex) 
    {
        weapons[weaponIndex].SetActive(false);
        weapons[weaponIndex].GetComponentInChildren<IWeapon>().enabled = false;

        for (int i = 0; i < weapons.Length; i++)// find the weapon with that input index
            if (i == newIndex)
            {
                weapons[i].SetActive(true);
                if (weaponIndex != 0)
                {
                    Instantiate(weaponList.weaponList[weaponIndex].drop, transform.position + 5*Vector3.down, transform.rotation);
                }
                weaponIndex = newIndex;
                
                yield return new WaitForSeconds(0.2f);

                weapons[i].GetComponentInChildren<IWeapon>().enabled = true;
                break;
            }

        UpdateWeaponToStat();
    }

    public IWeapon CheckCurrentWeapon() 
    {
        return weapons[weaponIndex].GetComponentInChildren<IWeapon>();
    }

    public void UpdateWeaponToStat() 
    {
        if (handSide == HandSide.Left)
        {
            playerData.leftWeapon = CheckCurrentWeapon();
        }
        else
        {
            playerData.rightWeapon = CheckCurrentWeapon();
        }
    }
}
