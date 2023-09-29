using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Attack", menuName ="Attack/Attack Data")]
public class AttackData_SO : ScriptableObject
{
    [Header("Damage Variables")]
    [Min(0f)]
    public float coolDown;
    public int damage;
    public float criticalMultiplier;
    public float criticalChance;

    private bool isCritical;

    [Header("Enemy Data")]
    public float attackRange;
    public float shootRange;

    public int CurrentDamage()
    {
        float coreDamage = damage;

        if (isCritical)
        {
            coreDamage *= criticalMultiplier;
            Debug.Log("±©»÷£¡" + coreDamage);
        }
        return (int)coreDamage;
    }
}
