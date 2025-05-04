using UnityEngine;

[CreateAssetMenu(fileName = "NewHero", menuName = "Game/Hero")]
public class HeroData : ScriptableObject
{
    public string heroName;
    public Sprite icon;
    public GameObject heroPrefab;
    public int unlockCost;
    public string heroId; // Unique ID used for saving

    [TextArea]
    public string description;
}
