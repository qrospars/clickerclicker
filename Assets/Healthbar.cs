using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        
        float maxHealth = GoblinSpawner.instance.enemyBehaviour.health * GoblinSpawner.instance.enemyBehaviour.level;
        float currentHealth = GoblinSpawner.instance.goblin.health;
        transform.localScale = new Vector3(currentHealth / maxHealth,1,1);

        healthText.text = currentHealth + " / " + maxHealth;
    }
}
