using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    GameObject[] weapons;
    public int weaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        weapons = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            weapons[i] = transform.GetChild(i).gameObject;

        weapons[weaponIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            SwitchWeapon(1);
    }

    void SwitchWeapon(int newIndex) 
    {
        weapons[weaponIndex].SetActive(false);

        for (int i = 0; i < weapons.Length; i++)
            if (i == newIndex)
            {
                weapons[i].SetActive(true);
                break;
            }
        weaponIndex = newIndex;
    }
}
