/*****************************************************************************
// File Name : PopupFunctions.cs
// Author : Pierce Nunnelley
// Creation Date : January 30, 2026
//
// Brief Description : A general script for popup-related functions.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering.Universal;

public class PopupFunctions : MonoBehaviour
{
    [SerializeField] private GameObject[] _testPrefabs;
    [SerializeField] private int testScene;
    [SerializeField] private RenderTexture rt;
    [SerializeField] private int _targetPopupHeight = 5;

    private List<int> loadedPopupIDs = new List<int>();

    private DraggableUIElement targetPopup;

    public static Action minigameComplete;

    [SerializeField] private float _clearance = 50;

    private int popupCount = 0;

    public DraggableUIElement TargetPopup { get => targetPopup; set => targetPopup = value; }
    public async void TestLoadScene()
    {
        if(loadedPopupIDs.Count >= 1)
        {
            Debug.LogWarning("Not opening next minigame, previous still open");
        }
        else
        {
            GameObject g = Instantiate(_testPrefabs[UnityEngine.Random.Range(0, _testPrefabs.Length)], Vector2.down * (_clearance * popupCount), Quaternion.identity);
            loadedPopupIDs.Add(g.GetInstanceID());
        }
        
        //popupCount++;
    }

    public async void LoadScene(int index)
    {
        if (loadedPopupIDs.Count >= 1)
        {
            Debug.LogWarning("Not opening next minigame, previous still open");
        }
        else
        {
            GameObject g = Instantiate(_testPrefabs[index], Vector2.down * (_clearance * popupCount), Quaternion.identity);
            loadedPopupIDs.Add(g.GetInstanceID());
            AudioManager.PlaySound("VirusNotif");
        }
    }

    public void SetTargetPopup(DraggableUIElement target)
    {
        targetPopup = target;
    }

    public void KillScene(GameObject s)
    {
        if(s == null)
        {
            Debug.LogError("Failed to kill minigame-- root not found");
            return;
        }
        else if(loadedPopupIDs.Contains(s.GetInstanceID()))
        {
            loadedPopupIDs.Remove(s.GetInstanceID());
            Destroy(s);
            minigameComplete?.Invoke();
        }
        else
        {
            KillScene(s.transform.parent.gameObject);
        }
    }

    public GameObject GetObjectRoot(GameObject s)
    {
        if (s == null)
        {
            Debug.LogError("Failed to find minigame root-- root not found");
            return null;
        }
        else if (loadedPopupIDs.Contains(s.GetInstanceID()))
        {
            return (s);

        }
        else
        {
            return GetObjectRoot(s.transform.parent.gameObject);
        }
    }

    public void ReloadScene()
    {
        CaptchaCycle.currentCaptcha = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
