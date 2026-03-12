using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoorIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button attachedButton;
    [SerializeField] private Animator _AnimBase;
    private bool _isOpen = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked
        if (!_isOpen) _AnimBase.Play("DoorOpen");
        _isOpen = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //start hovering
        if (!_isOpen) _AnimBase.Play("DoorHoverTransition");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //stop hovering
        if (!_isOpen) _AnimBase.Play("DoorReturnIdle");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //when click released
        
    }

    public void OpenBrowser()
    {
        // this method is called from an animation event after the door fully opens
        // (when implemented) should have the same functionality as the current panel -> task 1 button !!
        // somehow render the door behind the panels when it finishes animation
        // maybe just swap out the button for an identical functionless sprite?
        print("BROWSER OPEN");
    }
}
