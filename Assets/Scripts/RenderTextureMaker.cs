using UnityEngine;
using UnityEngine.UI;

public class RenderTextureMaker : MonoBehaviour
{
    [SerializeField] private Camera targetCam;

    public Camera TargetCam { get => targetCam; set => targetCam = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RenderTexture r = new RenderTexture(256, 256, 1);
        TargetCam.targetTexture = r;
        gameObject.GetComponent<RawImage>().texture = r;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
