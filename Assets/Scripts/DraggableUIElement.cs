using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUIElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas parentCanvas;
    private Vector2 offset;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        offset = (Vector2)gameObject.GetComponent<RectTransform>().position - eventData.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        SetDraggedPosition(eventData);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
