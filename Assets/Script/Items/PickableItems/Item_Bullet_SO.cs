using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Effect Item", menuName = "Item/Bullet Effect Item")]
public class Item_Bullet_SO : ItemData_SO
{
    [Header("bullet to be changed")]
    [SerializeField]GameObject bullet;

    public override void ApplyEffectOnPlayer(CharacterStats playerData)
    {
        playerData.attackData.bulletPrefab = bullet;
    }

    public override void DeleteEffectOnPlayer(CharacterStats playerData)
    {

        if (playerData.attackData.bulletPrefab == bullet)
        {
            playerData.attackData.bulletPrefab = null;
        }
        
    }


}
