using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "Webview/EventListener")]
public class WebViewEventScriptableObject : ScriptableObject
{
    [SerializeField] private string _actionName;
    [SerializeField] private GameObject _handlerPrefab;

    public string actionName => _actionName;
    public IMessageHandler messageHandler => _handlerPrefab.GetComponent<IMessageHandler>();

    private void OnValidate()
    {
        if (_handlerPrefab.GetComponent<IMessageHandler>() == null)
        {
            Debug.LogError($"Prefab: {_handlerPrefab.name} is not realises {nameof(IMessageHandler)}");
            _handlerPrefab = null;
        }
    }
}