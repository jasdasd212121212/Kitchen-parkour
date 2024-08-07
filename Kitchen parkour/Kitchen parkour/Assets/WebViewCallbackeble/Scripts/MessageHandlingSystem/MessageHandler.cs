using System.Collections.Generic;
using UnityEngine;

public class MessageHandler : MonoBehaviour
{
    [SerializeField] private WebViewMessageListener _listener;
    [SerializeField] private WebViewEventScriptableObject[] _events;

    [Space()]

    [SerializeField] private string _debugMessage = "eventAccept";

    private void Start()
    {
        _listener.OnMessageReceived += HandleMessage;
        _listener.OnMessageReceivedWithPayload += HandleMessageWithPayload;
    }

    private void OnDestroy()
    {
        _listener.OnMessageReceived += HandleMessage;
        _listener.OnMessageReceivedWithPayload += HandleMessageWithPayload;
    }

    private void HandleMessage(string message)
    {
        FindHandler(message)?.CallResponse();
    }

    private void HandleMessageWithPayload(string message, Dictionary<string, string> payload)
    {
        IMessageHandler handler = FindHandler(message);

        handler.SetPayload(payload);
        handler.CallResponse();
    }

    private IMessageHandler FindHandler(string message)
    {
        for (int i = 0; i < _events.Length; i++)
        {
            if (_events[i].actionName == message)
            {
                WebViewEventScriptableObject act = _events[i];
                IMessageHandler handler = act.messageHandler;

                return handler;
            }
        }

        return null;
    }

# if UNITY_EDITOR
    [ContextMenu("DEBUG_HandleMessage")]
    private void DEBUG_HandleMessage()
    {
        HandleMessage(_debugMessage);
    }
# endif
}