using UnityEngine;

public class StartGameUIStateMachine : MonoBehaviour
{
    [SerializeField] private ClickablePanel _jumpInput;
    [SerializeField] private RectTransform[] _startGameUIElements;

    private EnabledStartUIState _activeUIState;
    private DisabledStartUIState _inactiveUIState;

    private StateMachine _stateMachine;

    private void Start()
    {
        _activeUIState = new EnabledStartUIState(_startGameUIElements);
        _inactiveUIState = new DisabledStartUIState(_startGameUIElements);

        _stateMachine = new StateMachine(_activeUIState, new State[] { _activeUIState, _inactiveUIState }, false);

        _jumpInput.OnPointerDown += DisableUI;
    }

    private void OnDestroy()
    {
        _jumpInput.OnPointerDown -= DisableUI;
    }

    private void DisableUI()
    {
        _stateMachine.SetState(_inactiveUIState);
    }
}