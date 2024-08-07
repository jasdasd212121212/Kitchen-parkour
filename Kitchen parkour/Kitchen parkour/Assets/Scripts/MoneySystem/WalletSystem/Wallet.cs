using System;
using UnityEngine;

public static class Wallet
{
    private static int _coins;
    public static int lastDelta { get; private set; }

    private static bool _inited = false;

    private static ISavingService _moneySaver;
    public static event Action OnMoneyChanged;

    private static readonly int START_MONEY = 10;

    private static void Init()
    {
        if (_inited == true)
        {
            return;
        }

        _moneySaver = new WalletSaver(START_MONEY);
        _inited = true;
    }

    public static int money 
    {
        get
        {
            Init();

            _coins = _moneySaver.Load<int>(SavingSystemConfig.MONEY_SAVE_KEY);
            return _coins;
        }

        private set => throw new NotImplementedException();
    }

    public static void ChargeMoney(int money)
    {
        if (money < 0)
        {
            Debug.LogError($"Can`t charge <{money}> because '< 0'");
            return;
        }

        Init();
        _coins = _moneySaver.Load<int>(SavingSystemConfig.MONEY_SAVE_KEY);

        _coins += money;
        lastDelta = money;

        _moneySaver.Save<int>(SavingSystemConfig.MONEY_SAVE_KEY, _coins);

        OnMoneyChanged?.Invoke();
    }

    public static void DebitMoney(int money)
    {
        if (money < 0)
        {
            Debug.LogError($"Can`t debit <{money}> because '< 0'");
            return;
        }

        Init();
        _coins = _moneySaver.Load<int>(SavingSystemConfig.MONEY_SAVE_KEY);

        _coins -= money;
        lastDelta = -money;

        _moneySaver.Save<int>(SavingSystemConfig.MONEY_SAVE_KEY, _coins);

        OnMoneyChanged?.Invoke();
    }
}