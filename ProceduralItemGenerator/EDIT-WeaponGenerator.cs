public WeaponAffixSet affixSet; // assign in Inspector

private WeaponStats ApplyAffixes(WeaponStats stats)
{
    var prefix = affixSet.GetRandomAffix(AffixType.Prefix);
    var suffix = affixSet.GetRandomAffix(AffixType.Suffix);

    if (prefix != null)
    {
        stats.damage += prefix.bonusDamage;
        stats.fireRate += prefix.bonusFireRate;
        stats.attackSpeed += prefix.bonusAttackSpeed;
        stats.rarity += prefix.rarityIncrease;
        stats.itemName = $"{prefix.label} {stats.itemName}";
    }

    if (suffix != null)
    {
        stats.damage += suffix.bonusDamage;
        stats.fireRate += suffix.bonusFireRate;
        stats.attackSpeed += suffix.bonusAttackSpeed;
        stats.rarity += suffix.rarityIncrease;
        stats.itemName = $"{stats.itemName} {suffix.label}";
    }

    return stats;
}

protected override ItemStats GenerateStats()
{
    var stats = new WeaponStats
    {
        weaponType = this.weaponType,
        damage = Random.Range(10f, 100f),
        fireRate = weaponType == WeaponType.Ranged ? Random.Range(0.5f, 5f) : 0f,
        attackSpeed = weaponType == WeaponType.Melee ? Random.Range(0.5f, 2f) : 0f,
        rarity = Rarity.Common,
        itemName = weaponType == WeaponType.Melee ? "Blade" : "Blaster"
    };

    return ApplyAffixes(stats);
}
