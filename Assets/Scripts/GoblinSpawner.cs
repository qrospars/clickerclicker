using System;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSpawner : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public static GoblinSpawner instance;

    public Goblin goblin;

    public Sprite[] sprites;
    public Text scoreText;

    private void Start()
    {
        instance = this;
        enemyBehaviour.level = 1;
        enemyBehaviour.currentGoldReward = 0;
        SpawnGoblin();
    }

    private void SpawnGoblin()
    {
        goblin.GetComponent<Image>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
        goblin.health = enemyBehaviour.health * enemyBehaviour.level;

    }

    public void goToNext()
    {
        enemyBehaviour.GotToNext();
        //GameManager.Instance.currentGold += enemyBehaviour.currentGoldReward;
        MoneyParticleSpawner.Instance.CreateParticleEffect(enemyBehaviour.currentGoldReward, true);
        GameManager.Instance.UpdateGoldText();
        SpawnGoblin();
    }

    public void hitGoblin(float damage)
    {
        goblin.hit(damage);
    }
}
