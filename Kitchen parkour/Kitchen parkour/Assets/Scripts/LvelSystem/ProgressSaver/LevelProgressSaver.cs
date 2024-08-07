using UnityEngine;

public class LevelProgressSaver
{
    private ISavingService _savingService;
    private int _totalLevelCount;

    private LevelProgressSaveData _saveData;

    public int maxCompleatedLevel => _saveData.maxCompleatedLevel;
    public int currentLevel => _saveData.currentLevel;

    public LevelProgressSaver(ISavingService savingService, int levelsCount)
    {
        LevelProgressSaveData defaultSave = new LevelProgressSaveData();

        if (savingService == null)
        {
            _savingService = new JSONPlayerPrefsSerializer();
            Debug.LogError("Can`t set null savingService");
        }

        if (levelsCount < 1)
        {
            levelsCount = 1;
        }

        _totalLevelCount = levelsCount;
        _savingService = savingService;

        if (_savingService.HasSave(SavingSystemConfig.LEVELS_SAVE_KEY) == false)
        {
            _savingService.Save(SavingSystemConfig.LEVELS_SAVE_KEY, defaultSave);
        }

        _saveData = _savingService.Load<LevelProgressSaveData>(SavingSystemConfig.LEVELS_SAVE_KEY);
    }

    public void SaveLevelCompleate()
    {
        if ((_saveData.maxCompleatedLevel + 1) < _totalLevelCount)
        {
            _saveData.maxCompleatedLevel++;
            _saveData.currentLevel++;
        }
        else
        {
            if ((_saveData.currentLevel + 1) < _totalLevelCount)
            {
                _saveData.currentLevel++;
            }
            else
            {
                _saveData.currentLevel = 0;
            }
        }

        Save();
    }

    public void SetLevel(int levelIndex)
    {
        if (levelIndex > _saveData.maxCompleatedLevel)
        {
            Debug.LogError("Can`t set not compleated level");
            return;
        }

        levelIndex = Mathf.Clamp(levelIndex, 0, _totalLevelCount);

        _saveData.currentLevel = levelIndex;

        Save();
    }

    private void Save()
    {
        _savingService.Save(SavingSystemConfig.LEVELS_SAVE_KEY, _saveData);
    }
}