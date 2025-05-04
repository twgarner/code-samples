using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public Transform spawnPoint; // Set this to your starting location in the scene

    private void Start()
    {
        HeroData selectedHero = HeroManager.Instance.GetSelectedHero();

        if (selectedHero != null && selectedHero.heroPrefab != null)
        {
            Instantiate(selectedHero.heroPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No selected hero or prefab assigned!");
        }
    }
}
