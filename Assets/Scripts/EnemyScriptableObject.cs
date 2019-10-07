using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "ScriptableObjects/EnemyScriptableObject", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public int health = 10;
    public int level = 1;
    public int score = 0;

    public void gotToNext()
    {
        score += level * health;
        level++;
    }
}