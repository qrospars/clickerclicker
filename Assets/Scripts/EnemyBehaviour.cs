using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "ScriptableObjects/Enemy Behaviour", order = 1)]
public class EnemyBehaviour : ScriptableObject
{
    public int health = 10;
    public int level = 1;
    public int currentGoldReward = 0;

    public AnimationCurve heatlhScaling;

    public void GotToNext()
    {
        currentGoldReward = level * health;
        level++;
    }
}