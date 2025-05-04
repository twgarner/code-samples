#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace ProceduralItemGenerator.Editor
{
    public class WeaponGeneratorEditorWindow : EditorWindow
    {
        private WeaponGenerator generatorInstance;
        private GameObject previewInstance;

        [MenuItem("Tools/Procedural Weapon Generator")]
        public static void ShowWindow()
        {
            GetWindow<WeaponGeneratorEditorWindow>("Weapon Generator");
        }

        private void OnGUI()
        {
            GUILayout.Label("Weapon Generator Tool", EditorStyles.boldLabel);

            generatorInstance = (WeaponGenerator)EditorGUILayout.ObjectField(
                "Generator", generatorInstance, typeof(WeaponGenerator), true);

            if (generatorInstance == null)
            {
                EditorGUILayout.HelpBox("Assign a WeaponGenerator in the scene.", MessageType.Info);
                return;
            }

            if (GUILayout.Button("Generate Weapon"))
            {
                GenerateWeapon();
            }

            if (previewInstance != null && GUILayout.Button("Save as Prefab"))
            {
                PrefabSaver.SaveAsPrefab(previewInstance);
            }
        }

        private void GenerateWeapon()
        {
            if (previewInstance != null)
                DestroyImmediate(previewInstance);

            var generated = generatorInstance.GenerateItem();
            previewInstance = generated.visual;

            if (previewInstance != null)
            {
                previewInstance.transform.position = Vector3.zero;
                Selection.activeGameObject = previewInstance;
                EditorGUIUtility.PingObject(previewInstance);
            }
        }
    }
}
#endif
