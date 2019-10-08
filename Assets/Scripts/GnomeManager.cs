using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GnomeManager : MonoBehaviour
{
    public List<GnomeScriptableObject> gnomes;

    public GnomeScriptableObject gnomeRedScriptableObject;
    public GnomeScriptableObject gnomeGreenScriptableObject;

    public Text gnomeRedPrice;
    public Text gnomeGreenPrice;


    private void Start()
    {

        gnomeRedScriptableObject.amount = 0;
        gnomeRedPrice.text = gnomeRedScriptableObject.price.ToString();
        gnomeGreenPrice.text = gnomeGreenScriptableObject.price.ToString();
        InvokeRepeating("GnomeAttack", 0.0f, 1f);
    }

    private void Update()
    {
        
    }

    public void buyGnome(string color)
    {
        switch (color)
        {
            case "red":
                BuyGnomeHelper(gnomes[0], gnomeRedPrice);
                break;
            case "green":
                BuyGnomeHelper(gnomes[1], gnomeGreenPrice);
                break;
        }
    }

    private void BuyGnomeHelper(GnomeScriptableObject gnomeScriptableObject, Text priceText)
    {
        if (GoblinSpawner.instance.enemyScriptableObject.score >= gnomeScriptableObject.price)
        {
            GoblinSpawner.instance.enemyScriptableObject.score -= gnomeScriptableObject.price;
            gnomeScriptableObject.amount++;
            priceText.text = gnomeScriptableObject.price.ToString();
            GoblinSpawner.instance.scoreText.text = GoblinSpawner.instance.enemyScriptableObject.score.ToString();
        }
    }
    private void GnomeAttack()
    {
        GoblinSpawner.instance.hitGoblin(gnomeRedScriptableObject.amount * gnomeRedScriptableObject.damage);
        GoblinSpawner.instance.hitGoblin(gnomeGreenScriptableObject.amount * gnomeGreenScriptableObject.damage);
    }
}
