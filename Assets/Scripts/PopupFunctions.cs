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
using UnityEngine.Rendering.Universal;

public class PopupFunctions : MonoBehaviour
{
    [SerializeField] private GameObject _testPrefab;
    [SerializeField] private int testScene;
    [SerializeField] private RenderTexture rt;
    [SerializeField] private int _targetPopupHeight = 5;

    private List<int> loadedPopupIDs = new List<int>();

    private RectTransform targetPopup;

    [SerializeField] private float _clearance = 50;

    public RectTransform TargetPopup { get => targetPopup; set => targetPopup = value; }

    public async void TestLoadScene()
    {
        GameObject g = Instantiate(_testPrefab, Vector2.down * (_clearance * loadedPopupIDs.Count), Quaternion.identity);
        loadedPopupIDs.Add(g.GetInstanceID());
        /*await SceneManager.LoadSceneAsync(testScene, LoadSceneMode.Additive);
        Scene s = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        print(s.name);
        Camera[] test = GameObject.FindObjectsByType<Camera>(FindObjectsSortMode.None);
        foreach(Camera c in test)
        {
            if(c.gameObject.scene.handle == s.handle)
            {
                //c.targetTexture = rt;
            }
        }*/
    }

    public void SetTargetPopup(RectTransform target)
    {
        //targetPopup.GetComponentInParent<Canvas>().sortingOrder = 0;
        targetPopup = target;
        //targetPopup.GetComponentInParent<Canvas>().sortingOrder = _targetPopupHeight;
    }

    public void KillScene(GameObject s)
    {
        SceneManager.UnloadSceneAsync(s.scene);
    }
}
