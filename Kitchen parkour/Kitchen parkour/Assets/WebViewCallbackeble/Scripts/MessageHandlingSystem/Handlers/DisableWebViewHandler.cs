using System.Collections.Generic;
using UnityEngine;

public class DisableWebViewHandler : MonoBehaviour, IMessageHandler
{
    public void CallResponse()
    {
        UniWebView webView = FindObjectOfType<UniWebView>();

        if (webView != null)
        {
            Destroy(webView.gameObject);
        }
    }

    public void SetPayload(Dictionary<string, string> payload)
    {
        Debug.LogError("Not supported");
    }
}