using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    public Text healthText;
    public Text attackText;
    public Text defenceText;
    public Text speedText;
    public Text dashSpeedText;
    public Text dashCoolText;

    void Update()
    {
        var playerinformation = GameObject.Find("Player").GetComponent<CharacterStats>();
        var weaponLeft = GameObject.Find("LeftWeaponHolder").GetComponentInChildren<IWeapon>(false);
        var weaponRight = GameObject.Find("RightWeaponHolder").GetComponentInChildren<IWeapon>(false);
        healthText.text = string.Format("Health:{0}/{1}",playerinformation.characterData.currentHealth, playerinformation.characterData.maxHealth);
        attackText.text = string.Format("Attack:L:{0} R:{1}", weaponLeft.damageData.buffedDamage,weaponRight.damageData.buffedDamage);
        defenceText.text = string.Format("Defense:{0}", playerinformation.characterData.currentDefence);
        speedText.text = string.Format("Speed:{0}", playerinformation.characterData.currentSpeed);
        dashSpeedText.text = string.Format("Dash Speed:{0}", playerinformation.characterData.currentDashSpeed);
        dashCoolText.text = string.Format("Dash Cool:{0}", playerinformation.characterData.currentDashCool);
    }
}
