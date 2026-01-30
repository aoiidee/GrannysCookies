/*****************************************************************************
// File Name : PopupFunctions.cs
// Author : Pierce Nunnelley
// Creation Date : January 30, 2026
//
// Brief Description : This script allows a UI element to be clicked + dragged.
*****************************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUIElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas parentCanvas;
    private Vector2 offset;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        offset = (Vector2)gameObject.GetComponent<RectTransform>().position - eventData.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        offset = Vector2.zero;
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        gameObject.GetComponent<RectTransform>().position = eventData.position + offset;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentCanvas = gameObject.GetComponentInParent<Canvas>();
    }
}
