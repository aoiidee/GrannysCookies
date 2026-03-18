using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DesktopIconAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button attachedButton;
    [SerializeField] private Animator _animBase;
    [SerializeField] private string _soundEffect;

    private bool isHovering = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked
        _animBase.Play("ButtonBasePress");
        AudioManager.PlaySound(_soundEffect);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //start hovering
        isHovering = true;
        _animBase.Play("ButtonBaseHighlighted");
        AudioManager.PlaySound("IconAsc");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //stop hovering
        isHovering = false;
        _animBase.Play("ButtonBaseReturnIdle");
        AudioManager.PlaySound("IconDes");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //when click released
        if (isHovering) _animBase.Play("ButtonBaseRelease"); 
        else _animBase.Play("ButtonBaseIdle");
    }
}
