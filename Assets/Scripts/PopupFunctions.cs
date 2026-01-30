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
    [SerializeField] private Scene testScene;

    public void TestLoadScene()
    {
        SceneManager.LoadSceneAsync(testScene.buildIndex, LoadSceneMode.Additive);
    }
}
