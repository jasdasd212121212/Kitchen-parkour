using UnityEngine;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private GameObject _winPanel;

    [Space()]

    [SerializeField][Min(0.01f)] private float _panelShowDellay = 1f;

    [Space()]

    [SerializeField] private PlayerHealth _player;
    [SerializeField] private LevelLoader _level;

    private void Awake()
    {
        _player.OnDead += () => 
        {
            Invoke(nameof(ShowDeadPanel), _panelShowDellay);
        };

        _level.OnFinished += () =>
        {
            Invoke(nameof(ShowWinPanel), _panelShowDellay);
        };
    }

    private void ShowDeadPanel()
    {
        _winPanel.SetActive(false);
        _deadPanel.SetActive(true);
    }

    private void ShowWinPanel()
    {
        _winPanel.SetActive(true);
        _deadPanel.SetActive(false);
    }
}