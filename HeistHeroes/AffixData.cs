using UnityEngine;

public enum AffixType { Prefix, Suffix }

[CreateAssetMenu(fileName = "NewAffix", menuName = "Loot/Affix")]
public class AffixData : ScriptableObject
{
    public string affixLabel;         // e.g., "Reinforced", "of Fire Resistance"
    public AffixType affixType;
    public string statModified;       // e.g., "damage", "reloadSpeed", "coldResistance"
    public float value;               // e.g., +10%
}
