using UnityEngine;

public class EnabledStartUIState : State
{
    private RectTransform[] _uiElements;

    public EnabledStartUIState(RectTransform[] uiElements)
    {
        if (uiElements == null)
        {
            Debug.LogError($"Critical Error -> Can`t create <{nameof(EnabledStartUIState)}> with null uiElements !");
            return;
        }

        _uiElements = uiElements;
    }

    public override void Entry()
    {
        SetUIActive(true);
    }

    public override void Exit()
    {
        SetUIActive(false);
    }

    private void SetUIActive(bool state)
    {
        foreach (RectTransform uiElement in _uiElements)
        {
            uiElement.gameObject.SetActive(state);
        }
    }
}