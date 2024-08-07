using UnityEngine;
using System;
using System.Collections.Generic;

public class HatShopMainModule : MonoBehaviour
{
    [SerializeField] private HatActionButton _actionButton;
    [SerializeField] private HastShopItemData[] _hats;

    private int _currentHatIndex;
    private HatShopSaver _saver;

    public HastShopItemData[] hats => _hats;

    public event Action<int> OnFlipHat;

    public event Action OnBuyHat;
    public event Action OnChooseHat;

    public event Action OnHatBuyingRejected;

    private HatShopDelegates.BuyHatEvent _buyEvent;
    private HatShopDelegates.ChooseHatEvent _chooseEvent;

    public int currentChoosenHatIndex => _saver.currentChoosenHatIndex;
    public bool hasChoosenHat => _saver.hasChoosenHat;
    public int[] buyedHatsIndexes
    {
        get
        {
            List<int> buyedHats = new List<int>();

            for (int i = 0; i < _saver.hats.Length; i++)
            {
                if (_saver.hats[i].isByued == true)
                {
                    buyedHats.Add(i);
                }
            }

            return buyedHats.ToArray();
        }

        private set { Debug.LogError("Can`t set buyedHatsIndexes"); }
    }

    private void Awake()
    {
        _saver = new HatShopSaver(new JSONPlayerPrefsSerializer(), _hats.Length);

        _buyEvent = new HatShopDelegates.BuyHatEvent(BuyHat);
        _chooseEvent = new HatShopDelegates.ChooseHatEvent(ChooseHat);

        _actionButton.Init(_buyEvent, _chooseEvent);

        _actionButton.OnClick += HandleHatState;
        HandleHatState();
    }

    private void OnDestroy()
    {
        _actionButton.OnClick -= HandleHatState;
    }

    public void FlipNextHat()
    {
        if ((_currentHatIndex + 1) > (_hats.Length - 1))
        {
            _currentHatIndex = 0;
        }
        else
        {
            _currentHatIndex++;
        }

        HandleHatState();
        OnFlipHat?.Invoke(_currentHatIndex);
    }

    public void FlipBackHat()
    {
        if ((_currentHatIndex - 1) < 0)
        {
            _currentHatIndex = (_hats.Length - 1);
        }
        else
        {
            _currentHatIndex--;
        }

        HandleHatState();
        OnFlipHat?.Invoke(_currentHatIndex);
    }

    private void BuyHat()
    {
        if (Wallet.money < _hats[_currentHatIndex].cost)
        {
            OnHatBuyingRejected?.Invoke();
            return;
        }

        _saver.ByuHat(_currentHatIndex);
        Wallet.DebitMoney(_hats[_currentHatIndex].cost);

        OnBuyHat?.Invoke();
    }

    private void ChooseHat()
    {
        _saver.ChooseHat(_currentHatIndex);
        OnChooseHat?.Invoke();
    }

    private void HandleHatState()
    {
        bool isBuyed = _saver.hats[_currentHatIndex].isByued;
        bool isChoosen = _saver.hats[_currentHatIndex].isChoosen;

        if (isChoosen == true)
        {
            _actionButton.SetChoosenHatMethod();
            return;
        }

        if (isBuyed == true && isChoosen == false)
        {
            _actionButton.SetChooseHatMethod();
            return;
        }

        if (isBuyed == false && isChoosen == false)
        {
            _actionButton.SetByuHatMethod();
        }
    }
}