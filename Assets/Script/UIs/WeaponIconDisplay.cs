using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class WeaponIconDisplay : MonoBehaviour
{
    public HandSide handSide;
    PlayerSwitchWeapon currentHolder;
    CharacterStats playerStats;
    public Image currentIcon;
    public Slider cdMask;

    void Start()
    {
        //找到场景中存在的玩家
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<CharacterStats>();
        PlayerSwitchWeapon[] holders = player.GetComponentsInChildren<PlayerSwitchWeapon>();

        //查找是否为右手，是则返回右手holder，否则返回左手holder
        foreach (var holder in holders)
        {
            if (handSide == holder.handSide )
            {
                currentHolder = holder;
            }
        }
        
        
    }

    void Update()
    {
        var currentWeapon = currentHolder.CheckCurrentWeapon();

        currentIcon.sprite = currentWeapon.damageData.icon;
        cdMask.value = currentWeapon.CheckCurrentCooldown() / currentWeapon.damageData.buffedCooldown;
    }
}
