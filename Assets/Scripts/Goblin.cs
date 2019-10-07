using System;
using System.Collections;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public float health;

    public void hit()
    {
       
        health--;
        if (health <= 0)
        {
            Die();
        }
    }
    public void hit(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void OnMouseUp()
    {
        hit();
    }

    private void Die()
    {
        GoblinSpawner.instance.goToNext();
    }
}
