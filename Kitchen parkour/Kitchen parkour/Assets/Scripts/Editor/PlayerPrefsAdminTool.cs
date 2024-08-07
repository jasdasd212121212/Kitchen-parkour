using UnityEditor;
using UnityEngine;

public class PlayerPrefsAdminTool
{
    [MenuItem("Game design tools/PPT/Remove all saves")] // P - player P - prefs T - tool
    public static void ResetAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }
}