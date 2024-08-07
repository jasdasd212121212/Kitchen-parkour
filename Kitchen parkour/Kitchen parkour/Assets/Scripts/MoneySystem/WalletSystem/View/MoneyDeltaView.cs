using UnityEngine;
using TMPro;

public class MoneyDeltaView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private void Start()
    {
        Wallet.OnMoneyChanged += UpdateUI;
        UpdateUI();
    }

    private void OnEnable()
    {
        UpdateUI();
    }

    private void OnDestroy()
    {
        Wallet.OnMoneyChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _counterText.text = Wallet.lastDelta.ToString();
    }
}