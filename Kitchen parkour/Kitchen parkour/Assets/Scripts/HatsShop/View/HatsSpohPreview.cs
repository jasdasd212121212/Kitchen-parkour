using UnityEngine;

public class HatsSpohPreview : MonoBehaviour
{
    [SerializeField] private HatShopMainModule _shop;
    private GameObject[] _hats;

    private void Start()
    {
        SpawnItems();

        _shop.OnFlipHat += SetActiveOfHat;
    }

    private void OnDestroy()
    {
        _shop.OnFlipHat -= SetActiveOfHat;
    }

    private void SpawnItems()
    {
        _hats = new GameObject[_shop.hats.Length];

        for (int i = 0; i < _hats.Length; i++)
        {
            GameObject spawnedHat = Instantiate(_shop.hats[i].hatPrefab, transform.position, Quaternion.identity);
            _hats[i] = spawnedHat;

            spawnedHat.transform.SetParent(transform);
        }

        SetActiveOfHat(0);
    }

    private void SetActiveOfHat(int hatIndex)
    {
        hatIndex = Mathf.Clamp(hatIndex, 0, _shop.hats.Length);

        DisableAllHats();
        _hats[hatIndex].SetActive(true);
    }

    private void DisableAllHats()
    {
        for (int i = 0; i < _hats.Length; i++)
        {
            _hats[i].SetActive(false);
        }
    }
}