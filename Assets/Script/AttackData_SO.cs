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

    protected bool isCritical;

    [Header("Enemy Data")]
    public float attackRange;
    public float shootRange;

    [Header("Player Data")]
    public List<GameObject> bulletStack = new List<GameObject>();

    public virtual int CurrentDamage()
    {
        float coreDamage = damage;

        if (isCritical)
        {
            coreDamage *= criticalMultiplier;
            Debug.Log("±©»÷£¡" + coreDamage);
        }
        return (int)coreDamage;
    }

    public virtual bool CheckCritical()
    {
        float critialLimit = Random.value;

        if (critialLimit <= criticalChance)
            return true;

        return false;
    }
}
