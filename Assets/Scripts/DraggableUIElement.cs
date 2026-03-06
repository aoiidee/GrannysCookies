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

public class DraggableUIElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private Canvas parentCanvas;
    private Vector2 offset;
    private bool _draggable = false;

    public Canvas ParentCanvas { get => parentCanvas; set => parentCanvas = value; }
    public bool Draggable { get => _draggable; set => _draggable = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
        try
        {
            GameObject root = FindAnyObjectByType<PopupFunctions>().GetObjectRoot(this.gameObject);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObject.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out Vector2 relativePos);
            root.BroadcastMessage("AdjustedClick", (relativePos / gameObject.GetComponent<RectTransform>().sizeDelta) + (Vector2.one * 0.5f), SendMessageOptions.DontRequireReceiver);
            root.BroadcastMessage("AdjustedClick", (relativePos / gameObject.GetComponent<RectTransform>().sizeDelta) + (Vector2.one * 0.5f), SendMessageOptions.DontRequireReceiver);
        }
        catch
        {
            print("oopsies");
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if(Draggable)
        {
            offset = (Vector2)gameObject.GetComponent<RectTransform>().position - eventData.position;
            
        }

        try
        {
            FindAnyObjectByType<PopupFunctions>().SetTargetPopup(this);
        }
        catch
        {
            Debug.LogWarning("Failed to set as target popup!");
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (Draggable)
            SetDraggedPosition(eventData);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (Draggable)
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
        print(parentCanvas.name);
    }
}
