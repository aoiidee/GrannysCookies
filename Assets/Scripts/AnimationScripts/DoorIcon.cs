using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

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

        if (!_isOpen)
        {
            _AnimBase.Play("DoorHoverTransition");
            AudioManager.PlaySound("IconAsc");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //stop hovering
        if (!_isOpen)
        {
            _AnimBase.Play("DoorReturnIdle");
            AudioManager.PlaySound("IconDes");
        }

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

    public void ShimmerSound()
    {
        AudioManager.PlaySound("DoorShimmer");
    }

    public void OpenSmallSound()
    {
        AudioManager.PlaySound("DoorOpenSmall");
    }

    public void CloseSmallSound()
    {
        AudioManager.PlaySound("DoorCloseSmall");
    }

    public void SlamSound()
    {
        AudioManager.PlaySound("DoorSlam");
    }

    public void BigSound()
    {
        AudioManager.PlaySound("DoorGrow");
    }

    public void OpenSound()
    {
        AudioManager.PlaySound("DoorOpen");
    }
}
