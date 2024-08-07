using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UseMusicOption : MonoBehaviour, IOption
{
    [SerializeField] private Toggle _useMusicToggle;
    [SerializeField] private AudioMixer _mainMixer;
    private bool _useMusic;

    public void Load()
    {
        if (PlayerPrefs.HasKey(SettingsSavingConfig.USE_MUSIC_SAVE_KEY) == false)
        {
            _useMusic = true;
            PlayerPrefsExtanded.SetBool(SettingsSavingConfig.USE_MUSIC_SAVE_KEY, _useMusic);
        }
        else
        {
            _useMusic = PlayerPrefsExtanded.GetBool(SettingsSavingConfig.USE_MUSIC_SAVE_KEY);
        }

        RefreshView();
        RefreshModel();

        _useMusicToggle.onValueChanged.AddListener((bool b) =>
        {
            Change();
        });
    }

    public void Save()
    {
        PlayerPrefsExtanded.SetBool(SettingsSavingConfig.USE_MUSIC_SAVE_KEY, _useMusic);
    }

    private void RefreshView()
    {
        _useMusicToggle.isOn = _useMusic;
    }

    private void RefreshModel()
    {
        if (_useMusic == true)
        {
            _mainMixer.SetFloat("MusicVol", 1);
        }
        else
        {
            _mainMixer.SetFloat("MusicVol", 0);
        }
    }

    private void Change()
    {
        _useMusic = _useMusicToggle.isOn;
        Save();
        RefreshModel();
    }
}