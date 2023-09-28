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
        healthText.text = string.Format("Health:{0}",playerinformation.characterData.maxHealth);
        attackText.text = string.Format("Attack:{0}", playerinformation.attackData.damage);
        defenceText.text = string.Format("Defence:{0}", playerinformation.characterData.currentDefence);
    }
}
