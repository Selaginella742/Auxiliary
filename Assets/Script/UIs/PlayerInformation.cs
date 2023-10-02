using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    public Text healthText;
    public Text attackText;
    public Text defenceText;

    void Update()
    {
        var playerinformation = GameObject.Find("Player").GetComponent<CharacterStats>();
        var weaponLeft = GameObject.Find("LeftWeaponHolder").GetComponentInChildren<IWeapon>();
        var weaponRight = GameObject.Find("RightWeaponHolder").GetComponentInChildren<IWeapon>();
        healthText.text = string.Format("Health:{0}/{1}",playerinformation.characterData.currentHealth, playerinformation.characterData.maxHealth);
        attackText.text = string.Format("Attack:L:{0} R:{1}", weaponLeft.damageData.buffedDamage,weaponRight.damageData.buffedDamage);
        defenceText.text = string.Format("Defence:{0}", playerinformation.characterData.currentDefence);
    }
}
