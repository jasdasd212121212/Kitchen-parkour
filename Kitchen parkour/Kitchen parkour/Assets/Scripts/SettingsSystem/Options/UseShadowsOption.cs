using UnityEngine;
using UnityEngine.UI;

public class UseShadowsOption : MonoBehaviour, IOption
{
    [SerializeField] private Toggle _useShadowsToggle;

    public void Load()
    {
        if (PlayerPrefs.HasKey(SettingsSavingConfig.USE_SHADOWS) == false)
        {
            ShadowUsageStaticHolder.useShadows = true;
            Save();
        }
        else
        {
            ShadowUsageStaticHolder.useShadows = PlayerPrefsExtanded.GetBool(SettingsSavingConfig.USE_SHADOWS);
        }

        RefreshView();

        _useShadowsToggle.onValueChanged.AddListener(HandleToggleState);
    }

    public void Save()
    {
        PlayerPrefsExtanded.SetBool(SettingsSavingConfig.USE_SHADOWS, ShadowUsageStaticHolder.useShadows);
    }

    private void RefreshView()
    {
        _useShadowsToggle.isOn = ShadowUsageStaticHolder.useShadows;
    }

    private void HandleToggleState(bool state)
    {
        ShadowUsageStaticHolder.useShadows = state;
        Save();
        RefreshView();
    }
}