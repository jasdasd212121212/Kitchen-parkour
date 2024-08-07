using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [SerializeField][Min(1)] private int _coinCost;
    [SerializeField] private CoinEffects _effects;

    public void Collect()
    {
        Wallet.ChargeMoney(_coinCost);

        _effects?.Play();
        Destroy(gameObject);
    }
}