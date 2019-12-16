using UnityEngine;
using UnityEngine.UI;

public class GnomeHero : MonoBehaviour
{
    [SerializeField] private Image sprite;
    [SerializeField] private Image shadow;
    [SerializeField] private Image background;
    [SerializeField] private Text priceText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text gnomeName;
    [SerializeField] private Text upgradeText;

    private GnomeScriptableObject gnomeData;
    private bool disabled;

    public void Initialize(GnomeScriptableObject gnome = null, bool disabled = false)
    {
        if (gnome!=null)
            gnomeData = gnome;
        if (disabled)
        {
            this.disabled = disabled;
            upgradeText.text = "Buy";
            background.color = new Color(0.7f,0.7f,0.7f,0.5f);
        }

        UpdateGnomeData();
    }

    private void UpdateGnomeData()
    {
        priceText.text = gnomeData.price.ToString();
        levelText.text = gnomeData.Level.ToString();
        gnomeName.text = gnomeData.gnomeName.ToString();
        sprite.sprite = gnomeData.GetCurrentSprite();
        shadow.sprite = sprite.sprite;
    }

    public void Attack()
    {
        gnomeData.Attack();
    }

    public void UpgradeGnome()
    {
        if (!GameManager.Instance.CanBuy(gnomeData.price))
            return;
        if (!GameManager.Instance.currentHeroes.Contains(this))
        {
            upgradeText.text = "Upgrade";
            background.color = new Color(1, 1, 1, 1);
            GameManager.Instance.currentHeroes.Add(this);
        }
        gnomeData.Upgrade();
        UpdateGnomeData();

        if(disabled)
        {
            UpgradeManager.Instance.ShowNextHero();
            disabled = false;
        }
    }
}
