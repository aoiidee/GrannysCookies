/*****************************************************************************
// File Name : PopupFunctions.cs
// Author : Pierce Nunnelley
// Creation Date : January 30, 2026
//
// Brief Description : A general script for popup-related functions.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupFunctions : MonoBehaviour
{
    [SerializeField] private int testScene;

    public async void TestLoadScene()
    {
        await SceneManager.LoadSceneAsync(testScene, LoadSceneMode.Additive);
        Scene s = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        print(s.name);
        Camera[] test = GameObject.FindObjectsByType<Camera>(FindObjectsSortMode.None);
        foreach(Camera c in test)
        {
            Debug.Log(c.gameObject.scene.handle == s.handle);
        }
    }
}
