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
    public void OnPointerEnter(PointerEventData eventData)
    {
        onImage = true;
        //print("on image");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
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
            hold = true;
        }
        if(grab.WasReleasedThisFrame()) 
        {
            hold = false;
            traceCheckPoints.ReturnToCheckPoint();  
        }
        if(hold)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            GetComponent<RectTransform>().position = mousePosition;
        }
    }
    private void LateUpdate()
    {
        GetComponent<CircleCollider2D>().transform.position = GetComponent<RectTransform>().position;
    }
}
