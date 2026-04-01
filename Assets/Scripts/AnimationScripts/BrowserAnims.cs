using UnityEngine;

public class BrowserAnims : MonoBehaviour
{
    [SerializeField] private GameObject _fakeButton1;
    [SerializeField] private GameObject _fakeButton2;
    [SerializeField] private GameObject _fakeButton3;
    [SerializeField] private GameObject _fakeButton4;
    [SerializeField] private GameObject _fakeButton5;
    [SerializeField] private GameObject _fakeButton6;
    [SerializeField] private GameObject _mailButton;

    public void Enable1()
    {
        _fakeButton1.SetActive(true);
    }
    public void Enable2()
    {
        _fakeButton2.SetActive(true);
    }
    public void Enable3()
    {
        _fakeButton3.SetActive(true);
    }
    public void Enable4()
    {
        _fakeButton4.SetActive(true);
    }
    public void Enable5()
    {
        _fakeButton5.SetActive(true);
    }
    public void Enable6()
    {
        _fakeButton6.SetActive(true);
    }
    public void EnableMail()
    {
        _mailButton.SetActive(true);
    }
}
