using UnityEngine;
using System;

[Serializable]
public class HatSaveDataHolder
{
    [SerializeField]private HatShopSaveData[] _hats;
    public HatShopSaveData[] hats => _hats;

    public HatSaveDataHolder(HatShopSaveData[] hats)
    {
        if (hats == null)
        {
            Debug.LogError("Critica error -> hats is null");
        }

        _hats = hats;
    }
}