using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeUIController : MonoBehaviour
{
    private Label currencyLabel;
    private Button upgradeHealthButton;
    private Button upgradeInventoryButton;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        currencyLabel = root.Q<Label>("currencyLabel");
        upgradeHealthButton = root.Q<Button>("upgradeHealthButton");
        upgradeInventoryButton = root.Q<Button>("upgradeInventoryButton");

        upgradeHealthButton.clicked += () => AttemptUpgrade("Health", 100);
        upgradeInventoryButton.clicked += () => AttemptUpgrade("Inventory", 150);

        UpdateCurrencyDisplay();
    }

    void AttemptUpgrade(string type, int cost)
    {
        if (ProgressionManager.Instance.SpendCurrency(cost))
        {
            PlayerPrefs.SetInt($"Upgrade_{type}", 1);
            PlayerPrefs.Save();
            UpdateCurrencyDisplay();
        }
        else
        {
            Debug.Log("Not enough currency.");
        }
    }

    void UpdateCurrencyDisplay()
    {
        currencyLabel.text = "Currency: " + ProgressionManager.Instance.TotalCurrency;
    }
}
