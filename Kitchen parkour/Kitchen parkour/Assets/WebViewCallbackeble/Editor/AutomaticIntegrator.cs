using UnityEditor;
using UnityEngine;

public class AutomaticIntegrator
{
    [MenuItem("WebviewAutomaticIntegrator/IntegratePrefab")]
    public static void Integrate()
    {
        GameObject loaded = Resources.Load<GameObject>("Prefabs/Webview");

        Debug.Log(loaded);
        GameObject instantiated = PrefabUtility.InstantiatePrefab(loaded.gameObject) as GameObject;

        EditorUtility.SetDirty(instantiated);
    }
}