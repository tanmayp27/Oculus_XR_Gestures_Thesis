using UnityEditor;
using UnityEngine;

namespace Chain
{
    public class HoleCreatorOpener : EditorWindow
    {
        [MenuItem("Tools/Chain Generator/Hole Creator")]
        public static void ShowWindow()
        {
            GameObject prefab = PathHelper.FindObjectByGuid("HoleCreator");

            if (prefab != null)
                AssetDatabase.OpenAsset(prefab);
            else
                Debug.LogError("Hole Creator Prefab not found at the specified path.");
        }
    }
}