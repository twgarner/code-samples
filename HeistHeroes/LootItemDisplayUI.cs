using UnityEngine;
using UnityEngine.UIElements;

public class LootItemDisplayUI : MonoBehaviour
{
    public UIDocument uiDocument;

    public void ShowLootItem(LootItem item)
    {
        var root = uiDocument.rootVisualElement;
        var itemNameLabel = root.Q<Label>("itemName");
        var affixList = root.Q<VisualElement>("affixList");

        itemNameLabel.text = FormatItemName(item);
        itemNameLabel.style.color = GetRarityColor(item.rarity);

        affixList.Clear();

        foreach (var affix in item.affixes)
        {
            var affixLabel = new Label($"{affix.label}: +{affix.value} {affix.statModified}");
            affixLabel.AddToClassList("affix-entry");
            affixList.Add(affixLabel);
        }
    }

    string FormatItemName(LootItem item)
    {
        string affixPrefix = item.affixes.Find(a => a.type == AffixType.Prefix)?.label ?? "";
        string affixSuffix = item.affixes.Find(a => a.type == AffixType.Suffix)?.label ?? "";
        return $"{affixPrefix} {item.baseName} {affixSuffix}".Trim();
    }

    Color GetRarityColor(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common: return Color.white;
            case Rarity.Uncommon: return Color.green;
            case Rarity.Rare: return Color.blue;
            case Rarity.Epic: return new Color(0.6f, 0f, 1f); // purple
            case Rarity.Legendary: return new Color(1f, 0.6f, 0f); // orange
            default: return Color.gray;
        }
    }
}
