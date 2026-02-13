using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField] private List<ClipAndEnum> _sounds;

    public static AudioManager Instance { get => instance; set => instance = value; }
    public List<ClipAndEnum> Sounds { get => _sounds; set => _sounds = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}

[System.Serializable]
public struct ClipAndEnum
{
    [SerializeField] private string _clipName;
    [SerializeField] private AudioClip[] _clips;

    public string ClipName { get => _clipName; set => _clipName = value; }
    public AudioClip[] Clips { get => _clips; set => _clips = value; }
}
