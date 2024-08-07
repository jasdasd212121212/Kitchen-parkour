using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private PlayerActivityStateMachine _playerStateMachine;
    [SerializeField] private PlayerHitBox[] _hitBoxes;

    private bool _isAlive = true;

    public event Action OnDead;

    private void Start()
    {
        for (int i = 0; i < _hitBoxes.Length; i++)
        {
            _hitBoxes[i].OnKilled += Die;
        }

        _isAlive = true;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _hitBoxes.Length; i++)
        {
            _hitBoxes[i].OnKilled -= Die;
        }
    }

    private void Die()
    {
        if (_isAlive == false || this.enabled == false)
        {
            return;
        }

        _playerStateMachine.SetActivaePlayer(false);

        OnDead?.Invoke();
        _isAlive = false;
    }
}