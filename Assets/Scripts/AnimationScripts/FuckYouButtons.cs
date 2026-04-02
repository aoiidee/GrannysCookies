using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FuckYouButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button attachedButton;
    [SerializeField] private Animator _animBase;
    [SerializeField] private string _soundEffect;

    [SerializeField] private GameObject _errorPopup;
    [SerializeField] private Canvas _canvas;

    [SerializeField] private int _lowXSpawnValue;
    [SerializeField] private int _highXSpawnValue;
    [SerializeField] private int _lowYSpawnValue;
    [SerializeField] private int _highYSpawnValue;

    private bool isHovering = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        //when clicked
        _animBase.Play("ButtonBasePress");
        AudioManager.PlaySound(_soundEffect);

        GameObject ErrorPopup = Instantiate(_errorPopup, new Vector3(UnityEngine.Random.Range(_lowXSpawnValue, _highXSpawnValue), 
            UnityEngine.Random.Range(_lowYSpawnValue, _highYSpawnValue)), Quaternion.identity);
        ErrorPopup.transform.SetParent(_canvas.transform, false);
        ErrorPopup.transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //start hovering
        isHovering = true;
        //_animBase.Play("ButtonBaseHighlighted");
        //AudioManager.PlaySound("IconAsc");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //stop hovering
        isHovering = false;
        //_animBase.Play("ButtonBaseReturnIdle");
        //AudioManager.PlaySound("IconDes");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //when click released
        //if (isHovering) _animBase.Play("ButtonBaseRelease");
        //else _animBase.Play("ButtonBaseIdle");
    }
}
