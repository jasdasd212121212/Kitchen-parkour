using System.Collections.Generic;
using UnityEngine;

public class HyperrefHandler : MonoBehaviour, IMessageHandler
{
    private Dictionary<string, string> _payload;

    public void CallResponse()
    {
        UniWebView webView = FindObjectOfType<UniWebView>();

        string reference = "";
        _payload.TryGetValue("webRef", out reference);

        if (reference.Contains("https"))
        {
            reference = reference.Replace("https", "https://");
        }
        else if (reference.Contains("http"))
        {
            reference = reference.Replace("http", "https://");
        }

        webView.Load(reference);
        webView.Show();

        Debug.Log($"Reference: {reference}");
    }

    public void SetPayload(Dictionary<string, string> payload)
    {
        _payload = payload;
    }
}