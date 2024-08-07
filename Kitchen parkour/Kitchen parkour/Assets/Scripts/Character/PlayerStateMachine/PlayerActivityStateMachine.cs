using UnityEngine;

public class PlayerActivityStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerJumper _player;
    [SerializeField] private JumpInput _input;
    [SerializeField] private PlayerHealth _health;

    private StateMachine _stateMachine;

    private PlayerActiveState _activeState;
    private PlayerInactiveState _inactiveState;

    private void Start()
    {
        _activeState = new PlayerActiveState(_player, _input, _health);
        _inactiveState = new PlayerInactiveState(_player, _input, _health);

        _stateMachine = new StateMachine(_activeState, new State[] { _activeState, _inactiveState }, false);
    }

    public void SetActivaePlayer(bool state)
    {
        if (state == true)
        {
            _stateMachine.SetState(_activeState);
        }
        else
        {
            _stateMachine.SetState(_inactiveState);
        }
    }
}