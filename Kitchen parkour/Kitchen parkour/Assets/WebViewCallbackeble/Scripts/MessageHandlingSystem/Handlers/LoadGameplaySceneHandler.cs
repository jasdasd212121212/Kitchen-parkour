using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameplaySceneHandler : MonoBehaviour, IMessageHandler
{
    [SerializeField][Min(0)] private int _gameplaySceneIndex;
    private Dictionary<string, string> _payload;

    public void CallResponse()
    {
        SceneManager.LoadScene(_gameplaySceneIndex);
    }

    public void SetPayload(Dictionary<string, string> payload)
    {
        _payload = payload;
    }
}