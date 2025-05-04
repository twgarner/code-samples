using UnityEngine;

public enum Rarity { Common, Uncommon, Rare, Epic, Legendary }
public enum ItemType { Weapon, Armor, Utility }

[CreateAssetMenu(fileName = "NewLootItem", menuName = "Loot/LootItem")]
public class LootItemData : ScriptableObject
{
    public string baseName;       // e.g., "Pistol"
    public Sprite icon;
    public Rarity rarity;
    public ItemType type;
}
