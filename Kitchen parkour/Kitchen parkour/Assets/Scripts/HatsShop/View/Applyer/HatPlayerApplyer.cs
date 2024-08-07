using UnityEngine;

public class HatPlayerApplyer : MonoBehaviour
{
    [SerializeField] private Transform _hatsOrigin;
    [SerializeField] private HatShopMainModule _shop;

    [Space()]

    [SerializeField][Min(0)] private int _renderebleLayerID = 0;

    private GameObject[] _hats;

    private void Start()
    {
        SpawnObject();

        _shop.OnChooseHat += SetHat;
        SetHat();
    }

    private void OnDestroy()
    {
        _shop.OnChooseHat -= SetHat;
    }

    private void SetHat()
    {
        DisableAllHats();

        if (_shop.hasChoosenHat == true)
        {
            _hats[_shop.currentChoosenHatIndex].SetActive(true);
        }
    }

    private void DisableAllHats()
    {
        for (int i = 0; i < _hats.Length; i++)
        {
            _hats[i].SetActive(false);
        }
    }

    private void SpawnObject()
    {
        _hats = new GameObject[_shop.hats.Length];

        for (int i = 0; i < _hats.Length; i++)
        {
            GameObject hat = Instantiate(_shop.hats[i].hatPrefab, _hatsOrigin.position + _shop.hats[i].hatPrefab.transform.position, Quaternion.Euler(_hatsOrigin.eulerAngles + _shop.hats[i].hatPrefab.transform.eulerAngles));
            _hats[i] = hat;

            hat.transform.SetParent(_hatsOrigin);
            hat.gameObject.layer = _renderebleLayerID;
        }

        DisableAllHats();
    }
}