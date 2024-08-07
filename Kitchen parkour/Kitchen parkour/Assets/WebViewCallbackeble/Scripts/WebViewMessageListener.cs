using System.Collections.Generic;
using UnityEngine;
using System;

public class WebViewMessageListener : MonoBehaviour
{
    [SerializeField] private WebViewBootstrap _webViewBootstrap;
    [SerializeField] private bool _loadEverySceneLoad = false;

    private UniWebView _webView;

    public event Action<string> OnMessageReceived;
    public event Action<string, Dictionary<string, string>> OnMessageReceivedWithPayload;

    private void Start()
    {
        WebViewBootParametrsStaticHolder.shoulStartEverySceneLoad = _loadEverySceneLoad;

        if (WebViewBootParametrsStaticHolder.webViewEarlyShowen == true && WebViewBootParametrsStaticHolder.shoulStartEverySceneLoad == false)
        {
            return;
        }

        _webView = _webViewBootstrap.Boot();
        _webView.OnMessageReceived += HandleMessage;

        WebViewBootParametrsStaticHolder.webViewEarlyShowen = true;
    }

    private void OnDestroy()
    {
        try
        {
            _webView.OnMessageReceived -= HandleMessage;
        }
        catch { }
    }

    private void HandleMessage(UniWebView view, UniWebViewMessage message)
    {
        string stringMessage = message.RawMessage;
        Dictionary<string, string> payload = message.Args;

        stringMessage = stringMessage.Replace($"{message.Scheme}://", "").Split('?')[0];

        Debug.Log($"Unity receive message: {stringMessage}, with payload: {payload}");

        if (payload.Count > 0)
        {
            OnMessageReceivedWithPayload?.Invoke(stringMessage, payload);
        }
        else
        {
            OnMessageReceived?.Invoke(stringMessage);
        }
    }
}