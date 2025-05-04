using UnityEngine;
using System.Collections.Generic;

public class LootGenerator : MonoBehaviour
{
    public List<LootItemData> lootPool;
    public List<AffixData> prefixPool;
    public List<AffixData> suffixPool;

    public LootItem GenerateLoot()
    {
        var baseItem = lootPool[Random.Range(0, lootPool.Count)];

        LootItem newItem = new LootItem();
        newItem.baseName = baseItem.baseName;
        newItem.icon = baseItem.icon;
        newItem.rarity = RollRarity();
        newItem.type = baseItem.type;
        newItem.affixes = new List<AffixData>();

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
}
