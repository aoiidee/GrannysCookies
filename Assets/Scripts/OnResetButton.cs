using UnityEngine;
using UnityEngine.EventSystems;

public class OnResetButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool onButton;
    public void OnPointerEnter(PointerEventData eventData)
    {
        onButton = true;    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onButton = false;
    }
}
