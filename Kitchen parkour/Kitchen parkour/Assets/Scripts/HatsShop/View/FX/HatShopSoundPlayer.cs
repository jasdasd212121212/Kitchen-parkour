using UnityEngine;

public class HatShopSoundPlayer : MonoBehaviour
{
    [SerializeField] private HatShopMainModule _shop;

    [Space()]

    [SerializeField] private AudioSource _buySound;
    [SerializeField] private AudioSource _chooseSound;

    private void Start()
    {
        _shop.OnBuyHat += PlayBuySound;
        _shop.OnChooseHat += PlayChooseSound;
    }

    private void OnDestroy()
    {
        _shop.OnBuyHat -= PlayBuySound;
        _shop.OnChooseHat -= PlayChooseSound;
    }

    private void PlayBuySound()
    {
        _buySound.Play();
    }

    private void PlayChooseSound()
    {
        _chooseSound.Play();
    }
}