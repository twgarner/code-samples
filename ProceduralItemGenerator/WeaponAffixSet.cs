using System.Collections.Generic;
using UnityEngine;

namespace ProceduralItemGenerator
{
    [CreateAssetMenu(fileName = "WeaponAffixSet", menuName = "Procedural Item Generator/Affix Set")]
    public class WeaponAffixSet : ScriptableObject
    {
        public List<WeaponAffix> affixes;

        public WeaponAffix GetRandomAffix(AffixType type, Rarity itemRarity)
        {
            var pool = affixes.FindAll(a => 
                a.affixType == type && itemRarity >= a.minimumRarity
            );
        
            if (pool.Count == 0) return null;
            return pool[Random.Range(0, pool.Count)];
        }
    }
}
