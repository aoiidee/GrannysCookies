using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DesktopIconAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button attachedButton;
    [SerializeField] private Animator _animBase;
    [SerializeField] private string _soundEffect;

    private bool isHovering = false;

    [SerializeField] private GameObject _errorPopup;
    [SerializeField] private Canvas _canvas;

    //DO NOT SERIALIZE THESE VARIABLES!!! THEY HAVE TO STAY THE SAME ACROSS ALL INSTANCES
    private int lowXSpawnValue = -600;
    private int highXSpawnValue = 600;
    private int lowYSpawnValue = -300;
    private int highYSpawnValue = 300;

    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked
        _animBase.Play("ButtonBasePress");
        AudioManager.PlaySound(_soundEffect);

        GameObject ErrorPopup = Instantiate(_errorPopup, new Vector3(UnityEngine.Random.Range(lowXSpawnValue, highXSpawnValue),
            UnityEngine.Random.Range(lowYSpawnValue, highYSpawnValue)), Quaternion.identity);
        ErrorPopup.transform.SetParent(_canvas.transform, false);
        ErrorPopup.transform.localScale = new Vector3(1, 1, 1);
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
