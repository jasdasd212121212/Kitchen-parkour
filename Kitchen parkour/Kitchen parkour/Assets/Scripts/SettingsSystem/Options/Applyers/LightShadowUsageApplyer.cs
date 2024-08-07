using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightShadowUsageApplyer : MonoBehaviour
{
    private Light _selfLight;

    private void Awake()
    {
        _selfLight = GetComponent<Light>();

        ShadowUsageStaticHolder.OnUsageChanged += HandleUsage;

        HandleUsage(ShadowUsageStaticHolder.useShadows);
    }

    private void OnDestroy()
    {
        ShadowUsageStaticHolder.OnUsageChanged -= HandleUsage;
    }

    private void HandleUsage(bool usage)
    {
        _selfLight.shadows = usage == true ? LightShadows.Hard : LightShadows.None;
    }
}