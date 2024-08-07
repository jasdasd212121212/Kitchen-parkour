using UnityEngine;
using System;

[Serializable]
public class LevelObjectNode
{
    public LevelObjectNode(GameObject levelProp, float interval)
    {
        interval = Mathf.Clamp(interval, 0, float.MaxValue);

        if (levelProp == null)
        {
            Debug.LogError("Can`t add empty levelProp");
        }

        _propGameObject = levelProp;
        _distanceInterval = interval;
    }

    [SerializeField] private GameObject _propGameObject;
    [SerializeField][Min(0.01f)] private float _distanceInterval;

    public GameObject propGameObject => _propGameObject;
    public float distanceInterval => _distanceInterval;
}