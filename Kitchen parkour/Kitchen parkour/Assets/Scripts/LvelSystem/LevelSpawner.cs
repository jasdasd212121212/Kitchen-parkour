using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finishPrefab;

    [HideInInspector][SerializeField] private List<GameObject> _spawnedObjects = new List<GameObject>();
    private Transform _levelOriginPoint;

    public IReadOnlyList<GameObject> spawnedObjects => _spawnedObjects;
    public FinishTrigger finishTrigger { get; private set; }

    private void Start()
    {
        _levelOriginPoint = transform;
    }

    public void SpawnLevel(LevelObjectsHolder level)
    {
        if (level == null)
        {
            Debug.LogError($"Can`t spawn null level!");
            return;
        }

        if (level.levelObjects.Length == 0)
        {
            Debug.LogWarning($"Can`t spawn empty level!");
            return;
        }

        if (_levelOriginPoint == null)
        {
            _levelOriginPoint = transform;
        }

        TryClearLevel();

        for (int i = 0; i < level.levelObjects.Length; i++)
        {
            Vector3 lastSpawnedGameObject = _spawnedObjects.Count == 0 ? _levelOriginPoint.position : _spawnedObjects[i - 1].transform.position;
            Vector3 nextGameObjectPostion = CalculateNextSpawnPosition(lastSpawnedGameObject, level.levelObjects[i].distanceInterval);

            GameObject spawnedObject = Instantiate(level.levelObjects[i].propGameObject, nextGameObjectPostion, Quaternion.identity);

            _spawnedObjects.Add(spawnedObject);
        }

        finishTrigger = Instantiate(_finishPrefab, CalculateNextSpawnPosition(_spawnedObjects[_spawnedObjects.Count - 1].gameObject.transform.position, level.levelObjects[level.levelObjects.Length - 1].distanceInterval), Quaternion.identity);

        _spawnedObjects.Add(finishTrigger.gameObject);
    }

    public void TryClearLevel()
    {
        if (_spawnedObjects.Count == 0) 
        {
            return;
        }

        int length = _spawnedObjects.Count;

        for (int i = 0; i < length; i++)
        {
            GameObject popedObject = _spawnedObjects[i];

            if (Application.isPlaying == true)
            {
                Destroy(popedObject);
            }
            else
            {
                DestroyImmediate(popedObject);
            }
        }

        _spawnedObjects.Clear();
    }

    private Vector3 CalculateNextSpawnPosition(Vector3 lastSpawnedObjectPosition, float nexInterval)
    {
        return new Vector3(
                    _levelOriginPoint.position.x,
                    _levelOriginPoint.position.y,
                    lastSpawnedObjectPosition.z + nexInterval
                );
    }
}