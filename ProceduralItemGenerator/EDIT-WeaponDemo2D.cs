public Button savePrefabButton;


void Start()
{
    generateButton.onClick.AddListener(GenerateWeapon);
    savePrefabButton.onClick.AddListener(SaveCurrentWeapon);
    GenerateWeapon();
}

void SaveCurrentWeapon()
{
    if (currentWeapon != null)
    {
        PrefabSaver.SaveAsPrefab(currentWeapon);
    }
}
