using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterData_SO characterData;

    public AttackData_SO attackData;

    [HideInInspector] //Because it's not necessary to edit, I just want it work in other script :)
    public bool isCritical;

    #region All-character shared Read from Data_SO
    //These are all-character shared;
    public int MaxHelath 
    {
        get
        {
            if (characterData != null)
                return characterData.maxHealth;
            else return 0;
        }
        set
        {
            characterData.maxHealth = value;
        }
    }

    public int CurrentHealth
    {
        get
        {
            if (characterData != null)
                return characterData.currentHealth;
            else return 0;
        }
        set
        {
            characterData.currentHealth = value;
        }
    }

    public int BaseDefence
    {
        get
        {
            if (characterData != null)
                return characterData.baseDefence;
            else return 0;
        }
        set
        {
            characterData.baseDefence = value;
        }
    }

    public int CurrentDefence
    {
        get
        {
            if (characterData != null)
                return characterData.currentDefence;
            else return 0;
        }
        set
        {
            characterData.currentDefence = value;
        }
    }
    #endregion


    #region Player-only shared Read from Data_SO
    //There are player only;
    public int BaseSpeed
    {
        get
        {
            if (characterData != null)
                return characterData.baseSpeed;
            else return 0;
        }
        set
        {
            characterData.baseSpeed = value;
        }
    }

    public int CurrentSpeed
    {
        get
        {
            if (characterData != null)
                return characterData.currentSpeed;
            else return 0;
        }
        set
        {
            characterData.currentSpeed = value;
        }
    }

    public int BaseDashCool
    {
        get
        {
            if (characterData != null)
                return characterData.baseDashCool;
            else return 0;
        }
        set
        {
            characterData.baseDashCool = value;
        }
    }

    public int CurrentDashCool
    {
        get
        {
            if (characterData != null)
                return characterData.currentDashCool;
            else return 0;
        }
        set
        {
            characterData.currentDashCool = value;
        }
    }
    #endregion

    #region Combat Calculate

    public void TakeDamage(CharacterStats attacker, CharacterStats defencer)
    {
        int damage = Mathf.Max(attacker.CurrentDamage()-defencer.CurrentDefence, 0);

        //TODO: update UI and exp
    }

    private int CurrentDamage()
    {
        float coreDamage = UnityEngine.Random.Range(attackData.minDamage, attackData.maxDamage);

        if (isCritical)
        {
            coreDamage *= attackData.criticalMultiplier;
            Debug.Log("±©»÷£¡" + coreDamage);
        }
        return (int)coreDamage;
    }

    #endregion

}
