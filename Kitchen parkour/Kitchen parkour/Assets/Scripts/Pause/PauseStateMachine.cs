using UnityEngine;
using System;

public class PauseStateMachine : MonoBehaviour
{
    private PausedState _pausedState;
    private UnpausedState _unpausedState;

    private StateMachine _stateMachine;

    public event Action<bool> OnPauseStateChanged;

    private void Start()
    {
        _pausedState = new PausedState();
        _unpausedState = new UnpausedState();

        _stateMachine = new StateMachine(_unpausedState, new State[] { _pausedState, _unpausedState });
    }

    public void ChangePauseState(bool state)
    {
        if (state == true)
        {
            _stateMachine.SetState(_pausedState);
        }
        else
        {
            _stateMachine.SetState(_unpausedState);
        }

        OnPauseStateChanged?.Invoke(state);
    }
}