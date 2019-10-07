using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeManager : MonoBehaviour
{
    public GnomeScriptableObject gnomeScriptableObject;

    private void Start()
    {
        gnomeScriptableObject.amount = 0;
        InvokeRepeating("GnomeAttack", 0.0f, 1f);
    }

    private void Update()
    {
        
    }

    public void buyGnome()
    {
        if (GoblinSpawner.instance.enemyScriptableObject.score > gnomeScriptableObject.price)
        {
            GoblinSpawner.instance.enemyScriptableObject.score -= gnomeScriptableObject.price;
            gnomeScriptableObject.amount++;
        }
    }

    private void GnomeAttack()
    {
        GoblinSpawner.instance.hitGoblin(gnomeScriptableObject.amount * gnomeScriptableObject.damage);
    }
}
