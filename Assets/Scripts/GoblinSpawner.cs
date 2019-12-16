using System;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSpawner : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public static GoblinSpawner instance;

    public Goblin goblin;

    [SerializeField] private Text goblinName;
    [SerializeField] private Text level;

    public Sprite[] sprites;

    [SerializeField] private string[] goblinNamesList;

    private void Start()
    {
        instance = this;
        enemyBehaviour.level = 1;
        enemyBehaviour.currentGoldReward = 5;
        enemyBehaviour.currentHealth = 10;
        SpawnGoblin();
    }

    private void SpawnGoblin()
    {
        goblin.GetComponent<Image>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
        goblinName.text = goblinNamesList[UnityEngine.Random.Range(0, goblinNamesList.Length)];
        goblin.health = enemyBehaviour.currentHealth;
        level.text = enemyBehaviour.level.ToString();
    }

    public void goToNext()
    {
        //GameManager.Instance.currentGold += enemyBehaviour.currentGoldReward;
        MoneyParticleSpawner.Instance.CreateParticleEffect(enemyBehaviour.currentGoldReward, true);
        GameManager.Instance.UpdateGoldText();
        enemyBehaviour.GotToNext();
        SpawnGoblin();
    }

    public void hitGoblin(float damage)
    {
        goblin.hit(damage);
    }
}
