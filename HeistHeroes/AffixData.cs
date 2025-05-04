using UnityEngine;

[CreateAssetMenu(fileName = "NewAffix", menuName = "Loot/Affix")]
public class AffixData : ScriptableObject
{
    public string affixLabel;
    public AffixType affixType;
    public string statModified;

    public float baseMinValue = 1f;
    public float baseMaxValue = 5f;
}
