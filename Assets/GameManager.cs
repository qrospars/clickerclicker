using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentGold;
    private int highestGold;

    [SerializeField]
    private Text goldText;

    public List<GnomeScriptableObject> GnomesProgression;

    public List<GnomeHero> currentHeroes;

    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
        foreach (var gnome in GnomesProgression)
            gnome.Reset();
    }

    private void GnomeAttack()
    {
        foreach (var gnome in currentHeroes)
            gnome.Attack();
    }

    public void UpdateGoldText()
    {
        goldText.text = currentGold.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GnomeAttack", 0.0f, 1f);
    }

    public bool CanBuy(int price)
    {
        if (currentGold >= price)
        {
            currentGold -= price;
            UpdateGoldText();
            return true;
        }
        return false;
    }
}
