using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    public EnemyScriptableObject enemyScriptableObject;
    public GameObject entityToSpawn;
    public static GoblinSpawner instance;

    private Goblin goblin;

    private void Start()
    {
        instance = this;
        enemyScriptableObject.level = 1;
        enemyScriptableObject.score = 0;
        SpawnGoblin();
    }

    private void SpawnGoblin()
    {
        GameObject currentEntity = Instantiate(entityToSpawn, Vector3.zero, Quaternion.identity);
        goblin = currentEntity.GetComponent<Goblin>();
        goblin.health = enemyScriptableObject.health * enemyScriptableObject.level;

    }

    public void goToNext()
    {
        enemyScriptableObject.gotToNext();
        SpawnGoblin();
    }

    public void hitGoblin(float damage)
    {
        goblin.hit(damage);
    }
}
