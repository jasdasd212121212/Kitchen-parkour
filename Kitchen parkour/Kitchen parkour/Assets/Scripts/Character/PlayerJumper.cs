using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumper : MonoBehaviour, IJumpable
{
    [SerializeField][Min(1f)] private float _jumpForce;
    [SerializeField][Min(1f)] private float _forwardTorque;

    [Space()]

    [SerializeField][Min(1)] private int _maxJumpsCount;

    [Header("Physics")]

    [SerializeField][Min(0.1f)] private float _jumpCheckRadius = 1f;
    [SerializeField] private LayerMask _jumpableMask;

    private Rigidbody _selfRigidbody;
    private Transform _cachedTransfrom;
    private int _currentJumpsCount;

    public event Action OnJump;

    private void Start()
    {
        _selfRigidbody = GetComponent<Rigidbody>();
        _cachedTransfrom = transform;

        _currentJumpsCount = _maxJumpsCount;
    }

    private void FixedUpdate()
    {
        if (Physics.CheckSphere(_cachedTransfrom.position, _jumpCheckRadius, _jumpableMask))
        {
            _currentJumpsCount = _maxJumpsCount;
        }
    }

    public void Jump()
    {
        if (_currentJumpsCount > 0)
        {
            _selfRigidbody.velocity = Vector3.zero;

            _selfRigidbody.AddForce(Vector3.up * _jumpForce);
            _selfRigidbody.AddForce(Vector3.forward * _forwardTorque);

            _currentJumpsCount--;
            OnJump?.Invoke();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _jumpCheckRadius);
    }
#endif
}