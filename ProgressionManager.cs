using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance;

    public int TotalCurrency { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadProgression();
    }

    public void AddCurrency(int amount)
    {
        TotalCurrency += amount;
        SaveProgression();
    }

    public bool SpendCurrency(int amount)
    {
        if (TotalCurrency >= amount)
        {
            TotalCurrency -= amount;
            SaveProgression();
            return true;
        }

        return false;
    }

    public void SaveProgression()
    {
        PlayerPrefs.SetInt("TotalCurrency", TotalCurrency);
        PlayerPrefs.Save();
    }

    public void LoadProgression()
    {
        TotalCurrency = PlayerPrefs.GetInt("TotalCurrency", 0);
    }

    public void ResetProgression()
    {
        TotalCurrency = 0;
        PlayerPrefs.DeleteKey("TotalCurrency");
    }
}
