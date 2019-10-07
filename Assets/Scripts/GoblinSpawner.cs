using UnityEngine;
using UnityEngine.UI;

public class GoblinSpawner : MonoBehaviour
{
    public EnemyScriptableObject enemyScriptableObject;
    public static GoblinSpawner instance;

    public Goblin goblin;

    public Sprite[] sprites;
    public Text scoreText;

    private void Start()
    {
        instance = this;
        enemyScriptableObject.level = 1;
        enemyScriptableObject.score = 0;
        scoreText.text = "0";
        SpawnGoblin();
    }

    private void SpawnGoblin()
    {
        goblin.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
        goblin.health = enemyScriptableObject.health * enemyScriptableObject.level;

    }

    public void goToNext()
    {
        enemyScriptableObject.gotToNext();
        scoreText.text = enemyScriptableObject.score.ToString();
        SpawnGoblin();
    }

    public void hitGoblin(float damage)
    {
        goblin.hit(damage);
    }
}
