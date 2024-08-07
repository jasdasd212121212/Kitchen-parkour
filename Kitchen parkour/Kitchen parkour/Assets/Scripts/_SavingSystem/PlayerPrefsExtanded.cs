using UnityEngine;

public class PlayerPrefsExtanded : PlayerPrefs
{
    public static void SetBool(string key, bool val)
    {
        int saveValue = val == true ? 1 : 0;
        SetInt(key, saveValue);
    }

    public static bool GetBool(string key)
    {
        int loadedValue = GetInt(key);
        bool resultValue = loadedValue == 1 ? true : false;

        return resultValue;
    }
}