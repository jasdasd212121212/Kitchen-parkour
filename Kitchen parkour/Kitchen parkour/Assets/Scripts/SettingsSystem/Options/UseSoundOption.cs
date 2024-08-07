using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UseSoundOption : MonoBehaviour, IOption
{
    [SerializeField] private Toggle _useSoundsToggle;
    [SerializeField] private AudioMixer _mainMixer;
    private bool _useSounds;

    public void Load()
    {
        if (PlayerPrefs.HasKey(SettingsSavingConfig.USE_SOUNDS_SAVE_KEY) == false)
        {
            _useSounds = true;
            PlayerPrefsExtanded.SetBool(SettingsSavingConfig.USE_SOUNDS_SAVE_KEY, _useSounds);
        }
        else
        {
            _useSounds = PlayerPrefsExtanded.GetBool(SettingsSavingConfig.USE_SOUNDS_SAVE_KEY);
        }

        RefreshView();
        RefreshModel();

        _useSoundsToggle.onValueChanged.AddListener((bool b) => 
        {
            Change();
        });
    }

    public void Save()
    {
        PlayerPrefsExtanded.SetBool(SettingsSavingConfig.USE_SOUNDS_SAVE_KEY, _useSounds);
    }

    private void RefreshView()
    {
        _useSoundsToggle.isOn = _useSounds;
    }

    private void RefreshModel()
    {
        if (_useSounds == true)
        {
            _mainMixer.SetFloat("SoundsVol", 1);
        }
        else
        {
            _mainMixer.SetFloat("SoundsVol", 0);
        }
    }

    private void Change()
    {
        _useSounds = _useSoundsToggle.isOn;
        Save();
        RefreshModel();
    }
}