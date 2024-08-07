using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private PauseStateMachine _pause;

    [Space()]

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _pauseButton;

    private void Start()
    {
        _pause.OnPauseStateChanged += HandlePanelState;
    }

    private void OnDestroy()
    {
        _pause.OnPauseStateChanged -= HandlePanelState;
    }

    private void HandlePanelState(bool state)
    {
        _pausePanel.SetActive(state);
        _pauseButton.gameObject.SetActive(!state);
    }
}