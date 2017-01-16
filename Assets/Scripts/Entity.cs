using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum entityType
{
    none,
    player,
    enemy,
}

public abstract class Entity : MonoBehaviour {

    public float life = 10f;

    protected float currentLife = 0f;

    public entityType type = entityType.none;

    public void takeDamage(float amount)
    {
        currentLife -= amount;
        if (currentLife < 0f) die();
    }

    public abstract void die();
    
}
