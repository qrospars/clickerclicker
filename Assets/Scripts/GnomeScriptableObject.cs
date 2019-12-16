using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "ScriptableObjects/GnomeScriptableObject", order = 1)]
public class GnomeScriptableObject : ScriptableObject
{
    public string gnomeName = "default";
    
    public float damage = 1f;
    public int price = 10;
    public int maxLevel = 25;
    public List<Sprite> gnomeSprites;
    public AnimationCurve damageCurve;

    private int level = 0;
    public int startingPrice;
    public int startingDamage;

    public int Level { get => level; set => level = value; }

    public void Attack()
    {
        GoblinSpawner.instance.hitGoblin(damage);
    }

    public void Upgrade()
    {
        ++level;
        price = startingPrice + (int)(startingPrice * 10*damageCurve.Evaluate((float)level/maxLevel));
        damage++;
    }

    public Sprite GetCurrentSprite()
    {
        if (level == 0)
            return gnomeSprites[0];
        for (var i = 1; i < gnomeSprites.Count; i+= maxLevel/gnomeSprites.Count)
        {
            if (level <=i) return gnomeSprites[i / (maxLevel / gnomeSprites.Count)];
        }
        return gnomeSprites[gnomeSprites.Count-1];
    }

    public void Reset()
    {
        level = 0;
        price = startingPrice;
        damage = startingDamage;
    }
}