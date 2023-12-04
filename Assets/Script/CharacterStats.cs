using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] CharacterData_SO templateData;

    [SerializeField] AttackData_SO tempAttackData;

    public CharacterData_SO characterData;

    public AttackData_SO attackData;

    

    public event Action<int, int> UpdateHealthBarOnTop;

    [HideInInspector] //Because it's not necessary to edit, I just want it work in other script :)
    public bool isCritical;

    #region All-character shared Read from Data_SO
    //These are all-character shared;

    void Awake()
    {
        if (templateData != null)
            characterData = Instantiate(templateData);

        if (tempAttackData != null)
            attackData = Instantiate(tempAttackData);
    }

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
    public float BaseSpeed
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

    public float CurrentSpeed
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

    public float BaseDashCool
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

    public float CurrentDashCool
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

    public void TakeDamage(int hitDamage, CharacterStats defencer)
    {
        int damage = Mathf.Max(hitDamage-defencer.CurrentDefence, 0);
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        //TODO: update UI and exp
        UpdateHealthBarOnTop?.Invoke(CurrentHealth, MaxHelath);
    }

    #endregion

    void Start()
    {
        characterData.currentHealth = characterData.maxHealth;
        characterData.currentDashCool = characterData.baseDashCool;
        characterData.currentDefence = characterData.baseDefence;
        characterData.currentSpeed = characterData.baseSpeed;
        characterData.currentDashSpeed = characterData.dashSpeed;
        characterData.leftWeaponIndex = characterData.iniLeft;
        characterData.rightWeaponIndex = characterData.iniRight;
    }
}
