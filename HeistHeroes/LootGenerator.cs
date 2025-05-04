using UnityEngine;
using System.Collections.Generic;

public class LootGenerator : MonoBehaviour
{
    public List<LootItemData> lootPool;
    public List<RolledAffix> prefixPool;
    public List<RolledAffix> suffixPool;

    public LootItem GenerateLoot()
    {
        var baseItem = lootPool[Random.Range(0, lootPool.Count)];

        LootItem newItem = new LootItem();
        newItem.baseName = baseItem.baseName;
        newItem.icon = baseItem.icon;
        newItem.rarity = RollRarity();
        newItem.type = baseItem.type;
        newItem.affixes = new List<AffixData>();
        
        //After we get the affix and rarity, we want to call RollAffix. Then assign it to the list of affixes.
        if (newItem.rarity >= Rarity.Uncommon)
            newItem.affixes.Add(GetRandomAffix(prefixPool));

        if (newItem.rarity >= Rarity.Epic)
            newItem.affixes.Add(GetRandomAffix(suffixPool));

        return newItem;
    }

    Rarity RollRarity()
    {
        float roll = Random.value;
        if (roll < 0.60f) return Rarity.Common;
        if (roll < 0.85f) return Rarity.Uncommon;
        if (roll < 0.95f) return Rarity.Rare;
        if (roll < 0.99f) return Rarity.Epic;
        return Rarity.Legendary;
    }

    AffixData GetRandomAffix(List<AffixData> pool)
    {
        return pool[Random.Range(0, pool.Count)];
    }

    RolledAffix RollAffix(AffixData affix, Rarity rarity)
    {
        float multiplier = GetRarityMultiplier(rarity);
    
        return new RolledAffix
        {
            label = affix.affixLabel,
            statModified = affix.statModified,
            type = affix.affixType,
            value = Random.Range(affix.baseMinValue, affix.baseMaxValue) * multiplier
        };
    }
    
    float GetRarityMultiplier(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Uncommon: return 1.0f;
            case Rarity.Rare:     return 1.25f;
            case Rarity.Epic:     return 1.5f;
            case Rarity.Legendary:return 2.0f;
            default:              return 1.0f;
        }
    }
}
