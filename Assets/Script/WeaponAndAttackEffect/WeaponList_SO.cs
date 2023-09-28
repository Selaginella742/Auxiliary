using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon List", menuName = "Weapon/Weapon List Data")]
public class WeaponList_SO : ScriptableObject
{
    public List<GameObject> weaponList;
}
