using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "ScriptableObjects/Enemy Behaviour", order = 1)]
public class EnemyBehaviour : ScriptableObject
{
    public int health = 10;
    public int level = 1;


    public int currentGoldReward = 0; 
    public int currentHealth = 0;

    public int maxLevel;
    public AnimationCurve heatlhScaling;

    public void GotToNext()
    {
        currentHealth += 7 + (int)(10000 * heatlhScaling.Evaluate((float)level / maxLevel));
        currentGoldReward = (int)(currentHealth*0.5f);
        level++;
    }
}