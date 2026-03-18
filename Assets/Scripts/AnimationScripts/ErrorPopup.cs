using UnityEngine;

public class ErrorPopup : MonoBehaviour
{
    public void NotifSound()
    {
        AudioManager.PlaySound("Notification");
    }

    public void ErrorClose()
    {
        Destroy(gameObject);
    }
}
