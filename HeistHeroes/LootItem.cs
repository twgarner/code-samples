using UnityEngine;
using System.Collections.Generic;

public class LootItem
{
    public string baseName;
    public Sprite icon;
    public Rarity rarity;
    public ItemType type;
    public List<RolledAffix> affixes;
}
