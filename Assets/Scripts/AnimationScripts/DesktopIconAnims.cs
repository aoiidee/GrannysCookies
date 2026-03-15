using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DesktopIconAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button attachedButton;
    [SerializeField] private Animator _AnimBase;
    [SerializeField] private string _soundEffect;

    private bool isHovering = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked
        _AnimBase.Play("ButtonBasePress");
        AudioManager.PlaySound(_soundEffect);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //start hovering
        isHovering = true;
        _AnimBase.Play("ButtonBaseHighlighted");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //stop hovering
        isHovering = false;
        _AnimBase.Play("ButtonBaseReturnIdle");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //when click released
        if (isHovering) _AnimBase.Play("ButtonBaseRelease"); 
        else _AnimBase.Play("ButtonBaseIdle");
    }
}
