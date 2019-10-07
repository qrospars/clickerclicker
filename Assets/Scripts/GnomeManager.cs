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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            buyGnome();
        }
    }

    void buyGnome()
    {
        gnomeScriptableObject.amount++;
    }

    private void GnomeAttack()
    {
        GoblinSpawner.instance.hitGoblin(gnomeScriptableObject.amount * gnomeScriptableObject.damage);
    }
}
