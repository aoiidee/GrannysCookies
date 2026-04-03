using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GrabCircle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image tracer;
    private bool onImage;
    private bool hold;
    InputAction grab;
    private TraceCheckPoints traceCheckPoints;

    [SerializeField] private Animator _anim;
    [SerializeField] private RectTransform _spriteTransform;
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.PlaySound("IconAsc");
        _anim.Play("TracerHoverTransition");
        onImage = true;
        //print("on image");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AudioManager.PlaySound("IconDes");
        _anim.Play("TracerReturnIdle");
        onImage = false;
        //print("off image");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grab = InputSystem.actions.FindAction("Grab");
        traceCheckPoints = GameObject.FindFirstObjectByType<TraceCheckPoints>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(onImage && grab.WasPressedThisFrame())
        {
            _anim.Play("TracerHeld");
            hold = true;
        }
        if(grab.WasReleasedThisFrame()) 
        {
            hold = false;
            traceCheckPoints.ReturnToCheckPoint();
            _spriteTransform.position = GetComponent<RectTransform>().position;
            if (onImage)
            {
                _anim.Play("TracerHoverTransition");
            }
            else
            {
                _anim.Play("TracerReturnIdle");
            }
        }
        if(hold)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            GetComponent<RectTransform>().position = mousePosition;
            _spriteTransform.position = mousePosition;
        }
    }
    private void LateUpdate()
    {
        GetComponent<CircleCollider2D>().transform.position = GetComponent<RectTransform>().position;
    }

    public void ShimmerSound()
    {
        AudioManager.PlaySound("DoorShimmer");
    }
}
