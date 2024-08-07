using UnityEngine;

public class DisabledStartUIState : State
{
    private RectTransform[] _uiElements;

    public DisabledStartUIState(RectTransform[] uiElements)
    {
        if (uiElements == null)
        {
            Debug.LogError($"Critical Error -> Can`t create <{nameof(DisabledStartUIState)}> with null uiElements !");
            return;
        }

        _uiElements = uiElements;
    }

    public override void Entry()
    {
        SetUIActive(false);
    }

    public override void Exit()
    {
        SetUIActive(true);
    }

    private void SetUIActive(bool state)
    {
        foreach (RectTransform uiElement in _uiElements)
        {
            uiElement.gameObject.SetActive(state);
        }
    }
}