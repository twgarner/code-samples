using UnityEngine;
using UnityEngine.UIElements;

public class HeroSelectUIController : MonoBehaviour
{
    public VisualTreeAsset heroCardTemplate; // UXML Template for each hero card
    private Label currencyLabel;
    private ScrollView heroList;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        currencyLabel = root.Q<Label>("currencyLabel");
        heroList = root.Q<ScrollView>("heroList");

        RefreshUI();
    }

    void RefreshUI()
    {
        currencyLabel.text = "Currency: " + ProgressionManager.Instance.TotalCurrency;
        heroList.Clear();

        foreach (var hero in HeroManager.Instance.availableHeroes)
        {
            var card = heroCardTemplate.Instantiate();
            card.Q<Label>("heroName").text = hero.heroName;
            card.Q<Label>("heroDesc").text = hero.description;
            card.Q<Label>("heroCost").text = hero.unlockCost + " coins";

            var button = card.Q<Button>("actionButton");

            if (HeroManager.Instance.IsHeroUnlocked(hero.heroId))
            {
                button.text = "Select";
                button.clicked += () => HeroManager.Instance.SelectHero(hero);
            }
            else
            {
                button.text = "Unlock";
                button.clicked += () =>
                {
                    if (ProgressionManager.Instance.SpendCurrency(hero.unlockCost))
                    {
                        HeroManager.Instance.UnlockHero(hero);
                        RefreshUI();
                    }
                };
            }

            heroList.Add(card);
        }
    }
}
