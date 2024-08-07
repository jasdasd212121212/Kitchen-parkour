using UnityEngine;
using TMPro;

public class LevelIndexDisplay : MonoBehaviour
{
    [SerializeField] private LevelLoader _level;
    [SerializeField] private TextMeshProUGUI _displayText;

    private void Start()
    {
        _displayText.text = $"Level {_level.currentLevel}";
    }
}