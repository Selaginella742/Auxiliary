using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PickableWeapon : MonoBehaviour
{
    public string weaponName;
    [Tooltip("put the index of the dropped weapon in the weapon list data here")]
    public int weaponIndex;
    public Image weaponIcon;
    [TextArea] public string description;

    CharacterData_SO playerStat;

    //UI for weapon's infomation
    GameObject canvas;
    GameObject weaponInfoUITemplate;
    GameObject weaponInfoUIIns;
    RectTransform uiPos;
    Text nameUI;
    Text descriptionUI;
    Image iconUI;


    private void Start()
    {
        //find the player and its data - used for change weapon index
        var player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<CharacterStats>().characterData;

        //instantiate the ui panel
        canvas = GameObject.Find("ItemDropCanvas");
        weaponInfoUITemplate = Resources.Load<GameObject>("Prefabs/UI/WeaponDropUI");
        weaponInfoUIIns = Instantiate(weaponInfoUITemplate, canvas.transform);
        uiPos = weaponInfoUIIns.GetComponent<RectTransform>();
        weaponInfoUIIns.SetActive(false);

        //initalize the position of the ui panel
        var displayPos = Camera.main.WorldToScreenPoint(transform.position);
        displayPos.y += 200;
        uiPos.position = displayPos;

        //get child texts and images
        nameUI = weaponInfoUIIns.transform.GetChild(0).GetComponent<Text>();
        descriptionUI = weaponInfoUIIns.transform.GetChild(1).GetComponent<Text>();
        iconUI = weaponInfoUIIns.transform.GetChild(2).GetComponent<Image>();

        //initialize name, description, and icon
        if (weaponName != null)
            nameUI.text = weaponName;
        if (description != null)
            descriptionUI.text = description;
        if (weaponIcon != null)
            iconUI = weaponIcon;
    }

    private void Update()
    {
        var displayPos = Camera.main.WorldToScreenPoint(transform.position);
        displayPos.y += 200;
        uiPos.position = displayPos;
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")// check if the player is at the position
        {
            weaponInfoUIIns.SetActive(true);
            Debug.Log("CTRL + mouse to change");
            if (Input.GetKey(KeyCode.LeftControl)) // press left ctrl + right or left mouse button to change right or left weapon
            {
                if (Input.GetMouseButton(0))
                {
                    playerStat.leftWeaponIndex = weaponIndex;
                    Destroy(weaponInfoUIIns);
                    Destroy(this.gameObject);
                } else if (Input.GetMouseButton(1))
                {
                    playerStat.rightWeaponIndex = weaponIndex;
                    Destroy(this.gameObject);
                    Destroy(weaponInfoUIIns);
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        weaponInfoUIIns.SetActive(false);
    }
}
