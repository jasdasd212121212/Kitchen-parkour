using System;

[Serializable]
public class HatShopSaveData : IReadOnlyHatSave
{
    public bool byued;
    public bool choosen;

    public bool isByued => byued;
    public bool isChoosen => choosen;
}