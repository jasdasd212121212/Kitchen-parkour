using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class HatActionButton : MonoBehaviour
{
    [SerializeField] private HatActionButtonText _text;

    private Button _actionButton;

    private HatShopDelegates.BuyHatEvent _buyHatEvent;
    private HatShopDelegates.ChooseHatEvent _chooseHatEvent;

    private bool _inited = false;

    public event Action OnClick;

    private void Awake()
    {
        InitButton();
    }

    public void Init(HatShopDelegates.BuyHatEvent byuFunction, HatShopDelegates.ChooseHatEvent chooseHatFuntrion)
    {
        if (_inited == true)
        {
            return;
        }

        if (byuFunction == null || chooseHatFuntrion == null)
        {
            Debug.LogError($"Can`t init actionButton with null delegates byuDelegate {byuFunction}, chooseDelegate {chooseHatFuntrion}");
        }

        _buyHatEvent = byuFunction;
        _chooseHatEvent = chooseHatFuntrion;

        _inited = true;
    }

    public void SetByuHatMethod()
    {
        if (_actionButton == null)
        {
            InitButton();
        }

        _actionButton.onClick.RemoveAllListeners();

        _actionButton.onClick.AddListener(BuyHat);
        _actionButton.onClick.AddListener(CallClickEvent);

        _text.SetBuyText();
    }

    public void SetChooseHatMethod()
    {
        if (_actionButton == null)
        {
            InitButton();
        }

        _actionButton.onClick.RemoveAllListeners();

        _actionButton.onClick.AddListener(ChooseHat);
        _actionButton.onClick.AddListener(CallClickEvent);

        _text.SetChooseText();
    }

    public void SetChoosenHatMethod()
    {
        if (_actionButton == null)
        {
            InitButton();
        }

        _actionButton.onClick.RemoveAllListeners();
        _text.SetChoosenText();
    }

    private void BuyHat()
    {
        _buyHatEvent?.Invoke();
    }

    private void ChooseHat()
    {
        _chooseHatEvent?.Invoke();
    }

    private void CallClickEvent()
    {
        OnClick?.Invoke();
    }

    private void InitButton()
    {
        _actionButton = GetComponent<Button>();
    }
}