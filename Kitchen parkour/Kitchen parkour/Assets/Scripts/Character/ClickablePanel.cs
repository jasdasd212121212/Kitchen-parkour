using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClickablePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action OnPointerDown;
    public event Action OnPointerUp;

    public event Action<bool> OnPointerClick;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnPointerDown?.Invoke();
        OnPointerClick?.Invoke(true);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        OnPointerUp?.Invoke();
        OnPointerClick?.Invoke(false);
    }
}