using UnityEngine;

namespace ProceduralItemGenerator
{
    public enum AffixType { Prefix, Suffix }

    [CreateAssetMenu(fileName = "WeaponAffix", menuName = "Procedural Item Generator/Weapon Affix")]
    public class WeaponAffix : ScriptableObject
    {
        public AffixType affixType;
        public string label; // e.g., "Burning", "of Fury"
        
        [Header("Stat Modifiers")]
        public float bonusDamage;
        public float bonusFireRate;
        public float bonusAttackSpeed;

        [Header("Rarity Modifier")]
        public Rarity rarityIncrease;
    }
}
