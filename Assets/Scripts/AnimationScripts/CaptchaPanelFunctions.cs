using UnityEngine;
using System;

public class CaptchaPanelFunctions : MonoBehaviour 
{
    [SerializeField] private GameObject _yB;
    [SerializeField] private Animator _yBS;
    [SerializeField] private YesButton _yBB;
    [SerializeField] private GameObject _nB;
    [SerializeField] private Animator _nBS;
    [SerializeField] private NoButton _nBB;

    public void CaptchaReset()
    {
        _yBB.TurnOff();
        _nBB.TurnOff();
    }

    public void YesActivate()
    {
        _yB.SetActive(true);
        _yBB.TurnOn();
    }

    public void NoActivate()
    {
        _nB.SetActive(true);
        _nBB.TurnOn();
    }

    public void VirusNotifSound()
    {
        AudioManager.PlaySound("VirusNotif");
    }
}
