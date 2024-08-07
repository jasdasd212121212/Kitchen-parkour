using System;
using UnityEngine;

public class HatShopSaver
{
    private ISavingService _savingService;

    private HatSaveDataHolder _save;
    private HatSaveDataHolder _defaultSave;

    public IReadOnlyHatSave[] hats => _save.hats;

    public int currentChoosenHatIndex
    {
        get
        {
            int index = 0;

            for (int i = 0; i < _save.hats.Length; i++)
            {
                if (_save.hats[i].isChoosen == true)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private set { Debug.LogError("Can`t set a currentChoosenHatIndex"); }
    }

    public bool hasChoosenHat
    {
        get
        {
            for (int i = 0; i < _save.hats.Length; i++)
            {
                if (_save.hats[i].isChoosen == true)
                {
                    return true;
                }
            }

            return false;
        }

        private set { Debug.LogError("Can`t set a hasChoosenHat"); }
    }

    public HatShopSaver(ISavingService savingService, int hatsCount) 
    {
        if (savingService == null)
        {
            savingService = new JSONPlayerPrefsSerializer();
        }

        _savingService = savingService;

        _defaultSave = new HatSaveDataHolder(new HatShopSaveData[hatsCount]);
        Load();
    }

    private void Load()
    {
        if (_savingService.HasSave(SavingSystemConfig.HATS_SAVE_KEY) == false)
        {
            _save = _defaultSave;
            Save();
        }

        _save = _savingService.Load<HatSaveDataHolder>(SavingSystemConfig.HATS_SAVE_KEY);
    }

    private void Save() 
    {
        _savingService.Save(SavingSystemConfig.HATS_SAVE_KEY, _save);
    }

    private void UnchooseAllHats()
    {
        for (int i = 0; i < _save.hats.Length; i++)
        {
            _save.hats[i].choosen = false;
        }
    }

    public void ChooseHat(int hatIndex)
    {
        if (hatIndex < 0 || hatIndex > _save.hats.Length)
        {
            Debug.LogError($"Can`t choose a hat with index {hatIndex} because this index is not exist");
        }

        hatIndex = Mathf.Clamp(hatIndex, 0, _save.hats.Length - 1);

        UnchooseAllHats();

        _save.hats[hatIndex].choosen = true;
        Save();
    }

    public void ByuHat(int hatIndex)
    {
        if (hatIndex < 0 || hatIndex > _save.hats.Length)
        {
            Debug.LogError($"Can`t byu a hat with index {hatIndex} because this index is not exist");
        }

        hatIndex = Mathf.Clamp(hatIndex, 0, _save.hats.Length - 1);

        _save.hats[hatIndex].byued = true;
        Save();
    }
}