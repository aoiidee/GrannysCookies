using UnityEngine;

public class ErrorPopup : MonoBehaviour
{
    public void NotifSound()
    {
        AudioManager.PlaySound("ErrorPopup");
    }

    public void ErrorClose()
    {
        Destroy(gameObject);
    }
}
