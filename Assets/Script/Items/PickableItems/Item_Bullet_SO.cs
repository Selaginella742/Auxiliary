using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Effect Item", menuName = "Item/Bullet Effect Item")]
public class Item_Bullet_SO : ItemData_SO
{
    [Header("bullet to be changed")]
    [SerializeField]GameObject bullet;

    [Header("Repeat Pickup increasement")]
    [SerializeField] int damageIncrease;

    public override void ApplyEffectOnPlayer(CharacterStats playerData)
    {
        playerData.attackData.damage += damageIncrease;
        playerData.attackData.bulletStack.Insert(0, bullet);
    }

    public override void DeleteEffectOnPlayer(CharacterStats playerData)
    {
        playerData.attackData.damage -= damageIncrease;
        playerData.attackData.bulletStack.Remove(bullet);
    }


}
