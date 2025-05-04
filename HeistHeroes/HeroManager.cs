using UnityEngine;
using System.Collections.Generic;

public class HeroManager : MonoBehaviour
{
    public static HeroManager Instance;

    public List<HeroData> availableHeroes;
    public HeroData selectedHero;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public bool IsHeroUnlocked(string id)
    {
        return PlayerPrefs.GetInt("Hero_" + id, 0) == 1;
    }

    public void UnlockHero(HeroData hero)
    {
        PlayerPrefs.SetInt("Hero_" + hero.heroId, 1);
        PlayerPrefs.Save();
    }

    public void SelectHero(HeroData hero)
    {
        if (IsHeroUnlocked(hero.heroId))
        {
            selectedHero = hero;
            PlayerPrefs.SetString("SelectedHero", hero.heroId);
        }
    }

    public HeroData GetSelectedHero()
    {
        string savedId = PlayerPrefs.GetString("SelectedHero", "");
        return availableHeroes.Find(h => h.heroId == savedId);
    }
}
