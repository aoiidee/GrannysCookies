using UnityEngine;

public class CaptchaCycle : MonoBehaviour
{
    [SerializeField] private GameObject yesOrNoCaptcha;
    [SerializeField] private GameObject blockCaptcha;
    [SerializeField] private GameObject traceCaptcha;
    private YesOrNoCaptcha yesOrNo;
    private BlockCaptcha block;
    private DraggableUIElement draggableUIElement;
    public static int currentCaptcha = 0;
    public static bool miniGameActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yesOrNo = GameObject.FindFirstObjectByType<YesOrNoCaptcha>();   
        block = GameObject.FindFirstObjectByType<BlockCaptcha>();
        draggableUIElement = GameObject.FindFirstObjectByType<DraggableUIElement>();
        CaptchaSequence();
    }
    private void CaptchaSequence()
    {
        miniGameActive = true;
        switch(currentCaptcha)
        {
            case 0: StartYesOrNoCaptcha(); currentCaptcha++; break;
            case 1: StartBlockCaptcha(); currentCaptcha++; break;
            case 2: StartTraceCaptcha(); currentCaptcha++; break;
        }
    }
    private void StartYesOrNoCaptcha()
    {
        yesOrNo.SetUpFirstCaptcha();
        draggableUIElement.Draggable = true;
        yesOrNoCaptcha.SetActive(true);
        blockCaptcha.SetActive(false);
        traceCaptcha.SetActive(false);
    }
    private void StartBlockCaptcha()
    {
        blockCaptcha.SetActive(true);
        traceCaptcha.SetActive(false);
        yesOrNoCaptcha.SetActive(false);
        draggableUIElement.Draggable = true;
        block.SetUpBlocks();
    }
    private void StartTraceCaptcha()
    {
        draggableUIElement.Draggable = false;
        traceCaptcha.SetActive(true);
        blockCaptcha.SetActive(false);
        yesOrNoCaptcha.SetActive(false);
    }
    public void StartRandomCaptcha()
    {
        int currentCaptcha = Random.Range(0,3);
        switch(currentCaptcha)
        {
            case 0:
                StartYesOrNoCaptcha(); break;     
            case 1:
                StartBlockCaptcha(); break;
            case 2:
                StartTraceCaptcha(); break;

        }
    }
}
