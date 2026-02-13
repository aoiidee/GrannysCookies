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
    [SerializeField] private GameObject[] _testPrefabs;
    [SerializeField] private int testScene;
    [SerializeField] private RenderTexture rt;
    [SerializeField] private int _targetPopupHeight = 5;

    private List<int> loadedPopupIDs = new List<int>();

    private DraggableUIElement targetPopup;

    [SerializeField] private float _clearance = 50;

    public DraggableUIElement TargetPopup { get => targetPopup; set => targetPopup = value; }
    public async void TestLoadScene()
    {
        GameObject g = Instantiate(_testPrefabs[Random.Range(0, _testPrefabs.Length)], Vector2.down * (_clearance * loadedPopupIDs.Count), Quaternion.identity);
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
            
        }
        else
        {
            KillScene(s.transform.parent.gameObject);
        }
    }
}
