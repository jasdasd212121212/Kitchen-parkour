using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelObjectsHolder[] _levels;
    [SerializeField] private LevelSpawner _spawner;

    [Space()]

    [SerializeField] private PlayerActivityStateMachine _player;

    private LevelProgressSaver _progressSaver;

    public int compleatedLevelsCount => _progressSaver.maxCompleatedLevel + 1;
    public int currentLevel => _progressSaver.currentLevel + 1;

    public event Action OnFinished;

    private void Awake()
    {
        _progressSaver = new LevelProgressSaver(new JSONPlayerPrefsSerializer(), _levels.Length);

        LoadCurrentLevel();
    }

    private void LoadCurrentLevel()
    {
        _spawner.SpawnLevel(_levels[_progressSaver.currentLevel]);

        _spawner.finishTrigger.OnFinished += () => 
        { 
            OnFinished?.Invoke(); 
            _player.SetActivaePlayer(false);
        };
    }

    public void LoadLevel(int levelIndex)
    {
        _progressSaver.SetLevel(levelIndex);
        RestartLevel();
    }

    public void CompleateLevel()
    {
        _progressSaver.SaveLevelCompleate();
        RestartLevel();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}