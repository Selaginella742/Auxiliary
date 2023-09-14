using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICreature
{
    public int health;
    public int attack;
    public int defense;
    public float speed;

    public abstract void CheckCollision();

    public abstract void AttackMode();
}
