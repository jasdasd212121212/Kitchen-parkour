using System;

public static class ShadowUsageStaticHolder
{
    private static bool _useShadows;

    public static bool useShadows 
    {
        get => _useShadows;

        set
        {
            _useShadows = value;
            OnUsageChanged?.Invoke(_useShadows);
        } 
    }

    public static event Action<bool> OnUsageChanged;
}