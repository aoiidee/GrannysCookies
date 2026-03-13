using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoorIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button attachedButton;
    [SerializeField] private Animator _AnimBase;
    private bool _isOpen = false;

    [SerializeField] private GameObject _browser;
    [SerializeField] private PopupFunctions _popUpFunctions;


    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked
        if (!_isOpen)
        {
            _AnimBase.Play("DoorOpen");
            _isOpen = true;
        }
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

        _browser.SetActive(true);
        _popUpFunctions.LoadScene(2);
    }
}
