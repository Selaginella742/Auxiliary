using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class WeaponIconDisplay : MonoBehaviour
{
    [SerializeField] HandSide handSide;
    PlayerSwitchWeapon currentHolder;
    CharacterStats playerStats;
    [SerializeField] Image currentIcon;
    [SerializeField]Slider cdMask;

    void Start()
    {
        //�ҵ������д��ڵ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<CharacterStats>();
        PlayerSwitchWeapon[] holders = player.GetComponentsInChildren<PlayerSwitchWeapon>();

        

        //�����Ƿ�Ϊ���֣����򷵻�����holder�����򷵻�����holder
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
