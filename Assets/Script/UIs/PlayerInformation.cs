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
        //var weaponLeg = GameObject.Find("Player").GetComponent<Weapon>
        healthText.text = string.Format("Health:{0}/{1}",playerinformation.characterData.currentHealth, playerinformation.characterData.maxHealth);
        //attackText.text = string.Format("Attack:L:{0} R:{1}", playerinformation.attackData.damage);
        defenceText.text = string.Format("Defence:{0}", playerinformation.characterData.currentDefence);
    }
}
