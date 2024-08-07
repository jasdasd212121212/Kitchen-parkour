using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.gameObject.GetComponent<Coin>();

        if (coin != null) 
        {
            coin.Collect();
        }
    }
}