#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ProceduralItemGenerator
{
    public static class PrefabSaver
    {
        public static void SaveAsPrefab(GameObject weapon, string path = "Assets/GeneratedPrefabs")
        {
#if UNITY_EDITOR
            if (!AssetDatabase.IsValidFolder(path))
            {
                System.IO.Directory.CreateDirectory(path);
                AssetDatabase.Refresh();
            }

            string filename = $"{weapon.name}_{System.Guid.NewGuid().ToString().Substring(0, 6)}.prefab";
            string fullPath = $"{path}/{filename}";
            PrefabUtility.SaveAsPrefabAsset(weapon, fullPath);
            Debug.Log($"Saved prefab to: {fullPath}");
#else
            Debug.LogWarning("Prefab saving only works in the Unity Editor.");
#endif
        }
    }
}
