using UnityEngine;

public class CaptchaCycle : MonoBehaviour
{
    [SerializeField] private GameObject yesOrNoCaptcha;
    [SerializeField] private GameObject blockCaptcha;
    [SerializeField] private GameObject traceCaptcha;
    private YesOrNoCaptcha yesOrNo;
    private BlockCaptcha block;
    private DraggableUIElement draggableUIElement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yesOrNo = GameObject.FindFirstObjectByType<YesOrNoCaptcha>();   
        block = GameObject.FindFirstObjectByType<BlockCaptcha>();
        draggableUIElement = GameObject.FindFirstObjectByType<DraggableUIElement>();    
        StartCaptcha();
    }
    public void StartCaptcha()
    {
        int currentCaptcha = Random.Range(0,3);
        switch(currentCaptcha)
        {
            case 0: 
                yesOrNo.SetUpFirstCaptcha();
                draggableUIElement.Draggable = true;
                yesOrNoCaptcha.SetActive(true);  break;     
            case 1:
                blockCaptcha.SetActive(true);
                draggableUIElement.Draggable = true;
                block.SetUpBlocks();
                 break;
            case 2:
                draggableUIElement.Draggable = false;
                traceCaptcha.SetActive(true); break;

        }
    }
}
