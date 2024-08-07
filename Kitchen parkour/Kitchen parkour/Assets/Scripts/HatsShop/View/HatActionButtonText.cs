using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HatActionButtonText : MonoBehaviour
{
    [SerializeField] private string _buyText = "Buy";
    [SerializeField] private string _chooseText = "Choose";
    [SerializeField] private string _choosenText = "Choosen";

    private TextMeshProUGUI _text;

    private void Awake()
    {
        InitChooseButton();
    }

    public void SetChooseText()
    {
        if (_text == null)
        {
            InitChooseButton();
        }

        _text.text = _chooseText;
    }

    public void SetBuyText()
    {
        if (_text == null)
        {
            InitChooseButton();
        }

        _text.text = _buyText;
    }

    public void SetChoosenText() 
    {
        if (_text == null)
        {
            InitChooseButton();
        }

        _text.text = _choosenText;
    }

    private void InitChooseButton()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
}