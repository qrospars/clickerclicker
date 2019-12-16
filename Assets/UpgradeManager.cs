using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GnomeHero upgradePrefab;

    public static UpgradeManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        foreach(var hero in GameManager.Instance.currentHeroes)
        {
            var entry = Instantiate(upgradePrefab);
            entry.Initialize();
        }

        ShowNextHero();
    }

    public void ShowNextHero()
    {
        if (GameManager.Instance.currentHeroes.Count <= GameManager.Instance.GnomesProgression.Count)
        {
            var entry = Instantiate(upgradePrefab, gameObject.transform);
            entry.Initialize(GameManager.Instance.GnomesProgression[GameManager.Instance.currentHeroes.Count], true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
