using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Data Item", menuName = "Item/Attack Data Item")]
public class Item_Attack_SO : ItemData_SO
{
    [SerializeField] int damageIncrease;
    [SerializeField] float cooldownDecrease;
    [Range(0,1)]
    [SerializeField] float criticalChanceIncrease;
    [Min(0)]
    [SerializeField] float criticalMultiIncrease;

    public override void ApplyEffectOnPlayer(CharacterStats playerData)
    {
        playerData.attackData.damage += damageIncrease;
        playerData.attackData.coolDown -= cooldownDecrease;
        playerData.attackData.criticalChance += criticalChanceIncrease;
        playerData.attackData.criticalMultiplier += criticalMultiIncrease;
     }

    public override void DeleteEffectOnPlayer(CharacterStats playerData)
    {
        playerData.attackData.damage -= damageIncrease;
        playerData.attackData.coolDown += cooldownDecrease;
        playerData.attackData.criticalChance -= criticalChanceIncrease;
        playerData.attackData.criticalMultiplier -= criticalMultiIncrease;
    }
}
