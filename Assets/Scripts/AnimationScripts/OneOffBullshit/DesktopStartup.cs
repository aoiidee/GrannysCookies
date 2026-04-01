using UnityEngine;

public class DesktopStartup : MonoBehaviour
{
    [SerializeField] private Animator _wallpaperAnim;
    [SerializeField] private GameObject _Icon1;
    [SerializeField] private GameObject _Icon2;
    [SerializeField] private GameObject _Icon3;
    [SerializeField] private GameObject _Icon4;
    [SerializeField] private GameObject _Icon5;
    [SerializeField] private GameObject _Icon6;
    [SerializeField] private GameObject _Icon7;
    [SerializeField] private GameObject _Icon8;
    [SerializeField] private GameObject _doorIcon;

    public void ActivateWallpaper()
    {
        _wallpaperAnim.Play("WallpaperStart");
    }
    public void Activate1()
    {
        _Icon1.SetActive(true);
    }
    public void Activate2()
    {
        _Icon2.SetActive(true);
    }
    public void Activate3()
    {
        _Icon3.SetActive(true);
    }
    public void Activate4()
    {
        _Icon4.SetActive(true);
    }
    public void Activate5()
    {
        _Icon5.SetActive(true);
    }
    public void Activate6()
    {
        _Icon6.SetActive(true);
    }
    public void Activate7()
    {
        _Icon7.SetActive(true);
    }
    public void Activate8()
    {
        _Icon8.SetActive(true);
    }
    public void ActivateDoor()
    {
        _doorIcon.SetActive(true);
    }

    public void ActivationSounds()
    {
        AudioManager.PlaySound("IconAsc");
    }

}
