using UnityEngine;

[RequireComponent(typeof(LevelSpawner))]
public class LevelPreview : MonoBehaviour
{
    [SerializeField] private Camera _previewCamera;
    [SerializeField] private LevelSpawner _spawner;
    [SerializeField] private Vector2 _resolution;

    private bool _initialized = false;
    private Vector3 _startCameraPosition;
    private Vector3 _endCameraPosition;

    public RenderTexture previewImage { get; private set; }
    public Vector2 renderingREsolution => _resolution;

    private void OnValidate()
    {
        _resolution = new Vector2(Mathf.Clamp(_resolution.x, 0, 1920), Mathf.Clamp(_resolution.y, 0, 1920));
    }

    private void Start()
    {
        Destroy(gameObject);
    }

    public void Initialize()
    {
        if (_initialized == true)
        {
            return;
        }

        _previewCamera.gameObject.SetActive(true);

        previewImage = new RenderTexture(512, 512, 1);
        _previewCamera.targetTexture = previewImage;

        _startCameraPosition = transform.position;

        _initialized = true;
    }

    public void DisposePreview()
    {
        _spawner.TryClearLevel();
        previewImage = null;
        _previewCamera.targetTexture = null;

        _previewCamera.gameObject.SetActive(false);
        _initialized = false;
    }

    public void SpawnPreview(LevelObjectsHolder level)
    {
        _spawner.SpawnLevel(level);
    }

    public void SetPreviewCameraPercentPosition(float percent)
    {
        percent = Mathf.Clamp(percent, 0, 100);

        try
        {
            _endCameraPosition = new Vector3(_spawner.transform.position.x, _spawner.transform.position.y, _spawner.spawnedObjects[_spawner.spawnedObjects.Count - 1].transform.position.z);

            transform.position = Vector3.Lerp(_startCameraPosition, _endCameraPosition, Mathf.Clamp01(percent / 100));
        }
        catch { }
    }
}