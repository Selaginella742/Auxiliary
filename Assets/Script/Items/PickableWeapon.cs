using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableWeapon : MonoBehaviour
{
    public string weaponName;
    public int weaponIndex;
    [TextArea] public string description;

    CharacterData_SO playerStat;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<CharacterStats>().characterData;
    }
    void Update()
    {
        //the rotation when the item is dropped
        Vector3 currentAngle = transform.rotation.eulerAngles;
        currentAngle.y += 1;
        transform.rotation = Quaternion.Euler(currentAngle);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(0))
            {
                playerStat.leftWeaponIndex = weaponIndex;
                Destroy(this.gameObject);
            }
            else if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(1))
            {
                playerStat.rightWeaponIndex = weaponIndex;
                Destroy(this.gameObject);
            }

        }
    }
}
