using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableWeapon : MonoBehaviour
{
    public string weaponName;
    public int weaponIndex;
    [TextArea] public string description;

    CharacterData_SO playerStat;
    float sineCalc;
    Vector3 anchorPos;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<CharacterStats>().characterData;
        sineCalc = 0f;
        anchorPos = transform.position;
    }
    void FixedUpdate()
    {
        //the rotation when the item is dropped
        Vector3 currentAngle = transform.rotation.eulerAngles;
        currentAngle.y += 0.5f;
        transform.rotation = Quaternion.Euler(currentAngle);

        sineCalc += 0.05f;


        transform.position = new Vector3(anchorPos.x, anchorPos.y + Mathf.Sin(sineCalc), anchorPos.z);

        if (sineCalc >= Mathf.PI * 2)
            sineCalc = 0;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("CTRL + mouse to change");
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetMouseButton(0))
                {
                    playerStat.leftWeaponIndex = weaponIndex;
                    Destroy(this.gameObject);
                } else if (Input.GetMouseButton(1))
                {
                    playerStat.rightWeaponIndex = weaponIndex;
                    Destroy(this.gameObject);
                }
            }

        }
    }
}
