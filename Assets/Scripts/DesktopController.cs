using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopController : MonoBehaviour
{
    private Vector2 mousePosition;

    public Vector2 MousePosition { get => mousePosition; set => mousePosition = value; }
    public Vector2 RelativeMousePosition { get => mousePosition / new Vector2(Screen.width, Screen.height);}

    public void OnAim(InputValue iVal)
    {
        mousePosition = iVal.Get<Vector2>();
    }
    
    public void OnClick()
    {

    }
}
