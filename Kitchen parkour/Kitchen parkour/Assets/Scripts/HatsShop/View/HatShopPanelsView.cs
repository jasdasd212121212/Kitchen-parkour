using UnityEngine;

public class HatShopPanelsView : MonoBehaviour
{
    [SerializeField] private HatShopMainModule _shop;

    [Space()]

    [SerializeField] private GameObject _noMoneyPanel;

    private void Start()
    {
        _shop.OnHatBuyingRejected += ShowNoMoneyPanel;
    }

    private void OnDestroy()
    {
        _shop.OnHatBuyingRejected -= ShowNoMoneyPanel;
    }

    private void ShowNoMoneyPanel()
    {
        _noMoneyPanel.SetActive(true);
    }
}