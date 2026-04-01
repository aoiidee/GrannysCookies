using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class YesButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private Button attachedButton;
    [SerializeField] private Animator _animBase;

    [SerializeField] private bool _isCorrect;
    [SerializeField] private GameObject _yesParent;
    [SerializeField] private YesOrNoCaptcha _yONC;
    private bool _isPressedCorrect = false;

    [SerializeField] private bool _isSprite;


    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked
        if (!_isSprite)
        {
            if (_isCorrect)
            {
                _animBase.Play("YesButtonCorrect");
                _isPressedCorrect = true;
            }
            else
            {
                _animBase.Play("YesButtonFalse");
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //start hovering
        if (!_isSprite)
        {
            if (!_isPressedCorrect)
            {
                AudioManager.PlaySound("IconAsc");
                _animBase.Play("YesButtonHoverTransition");
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //stop hovering
        if (!_isSprite)
        {
            if (!_isPressedCorrect)
            {
                AudioManager.PlaySound("IconDes");
                _animBase.Play("YesButtonReturnIdle");
            }
        }
    }

    public void ButtonAct()
    {
        _yONC.YesButton();
    }

    public void SetButtonCorrect(bool x)
    {
        _isCorrect = x;
    }

    public void TurnOff()
    {
        _yesParent.SetActive(false);
    }

    public void TurnOn()
    {
        _isPressedCorrect = false;
        AudioManager.PlaySound("IconAsc");
        _animBase.Play("YesButtonReturnIdle");
    }

    public void CorrectSound()
    {
        AudioManager.PlaySound("CorrectBell");
    }
    public void WrongSound()
    {
        AudioManager.PlaySound("WrongBuzzer");
    }
}