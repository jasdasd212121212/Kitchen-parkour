using UnityEngine;
using System;

[Serializable]
public class LevelProgressSaveData
{
    [SerializeField] private int _maxCompleatedLevel = 1;
    [SerializeField] private int _currentLevel = 0;

    public int maxCompleatedLevel 
    {
        get => _maxCompleatedLevel;

        set
        {
            if (value < 0)
            {
                _maxCompleatedLevel = 0;
            }
            else
            {
                if (_maxCompleatedLevel >= _currentLevel)
                {
                    _maxCompleatedLevel = value;
                }
            }
        }
    }

    public int currentLevel
    {
        get => _currentLevel;

        set
        {
            if (value < 0)
            {
                _currentLevel = 0;
            }
            else
            {
                _currentLevel = value;
            }
        }
    }
}