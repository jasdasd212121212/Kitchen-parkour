using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private void Start()
    {
        Wallet.OnMoneyChanged += UpdateUI;  
        UpdateUI();
    }

    private void OnDestroy()
    {
        Wallet.OnMoneyChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _counterText.text = Wallet.money.ToString();
    }
}