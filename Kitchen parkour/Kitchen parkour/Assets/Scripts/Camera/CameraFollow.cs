using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 2f;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Vector2 _offset;
    private Transform _cachedTransform;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    public void LateUpdate()
    {
        Vector3 playerPosWithOffset = new Vector3(_playerPosition.position.x - _offset.x, _playerPosition.position.y, _playerPosition.position.z - _offset.y);
        Vector3 targetPos = Vector3.Lerp(_cachedTransform.position, playerPosWithOffset, _followSpeed);
        transform.position = new Vector3(_cachedTransform.position.x, _cachedTransform.position.y, targetPos.z);
    }
}
