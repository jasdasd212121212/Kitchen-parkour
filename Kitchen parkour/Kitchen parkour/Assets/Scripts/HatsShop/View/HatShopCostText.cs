using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HatShopCostText : MonoBehaviour
{
    [SerializeField] private HatShopMainModule _shop;

    [Space()]

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _coinIcon;

    private void Start()
    {
        _shop.OnFlipHat += UpdateText;

        UpdateText(0);
    }

    private void OnDestroy()
    {
        _shop.OnFlipHat -= UpdateText;
    }

    private void UpdateText(int hatIndex)
    {
        if (ContainsHat(hatIndex) == false)
        {
            _text.text = _shop.hats[hatIndex].cost.ToString();
            _coinIcon.gameObject.SetActive(true);
        }
        else
        {
            _text.text = "";
            _coinIcon.gameObject.SetActive(false);
        }
    }

    private bool ContainsHat(int hatIndex)
    {
        for (int i = 0; i < _shop.buyedHatsIndexes.Length; i++)
        {
            if (_shop.buyedHatsIndexes[i] == hatIndex)
            {
                return true;
            }
        }

        return false;
    }
}