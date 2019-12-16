using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Image greenBar;

    // Update is called once per frame
    void Update()
    {
        float maxHealth = GoblinSpawner.instance.enemyBehaviour.currentHealth;
        float currentHealth = GoblinSpawner.instance.goblin.health;
        greenBar.fillAmount = currentHealth / maxHealth;

        healthText.text = currentHealth + " / " + maxHealth;
    }
}
