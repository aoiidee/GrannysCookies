using UnityEngine;

public class CaptchaCycle : MonoBehaviour
{
    [SerializeField] private GameObject yesOrNoCaptcha;
    [SerializeField] private GameObject blockCaptcha;
    private YesOrNoCaptcha yesOrNo;
    private BlockCaptcha block;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yesOrNo = GameObject.FindFirstObjectByType<YesOrNoCaptcha>();   
        block = GameObject.FindFirstObjectByType<BlockCaptcha>();
        StartCaptcha();
    }
    public void StartCaptcha()
    {
        int currentCaptcha = Random.Range(0,2);
        switch(currentCaptcha)
        {
            case 0: 
                yesOrNo.SetUpFirstCaptcha();
                yesOrNoCaptcha.SetActive(true);  break;     
            case 1:
                blockCaptcha.SetActive(true);
                block.SetUpBlocks();
                 break;   
        }
    }
}
