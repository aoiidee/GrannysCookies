using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DesktopIconAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button attachedButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked down
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //start hovering
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //stop hovering
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //when click released
    }
}
