using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YesOrNoCaptcha : MonoBehaviour
{
    [SerializeField] private int captchaColor;
    [SerializeField] private int captchaPrompt;
    [SerializeField] private int maxQuestions;
    [SerializeField] private Image captchaImage;    
    [SerializeField] private TMP_Text promptText;
    [SerializeField] private TMP_Text promptEndText;
    [SerializeField] protected GameObject captchaGO;
    private int currentQuestion;
    private CaptchaCycle cycle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cycle = GameObject.FindFirstObjectByType<CaptchaCycle>();      
    }
    /// <summary>
    /// Created both the prompt and selects the image color
    /// </summary>
    public void SetUpFirstCaptcha()
    {
        captchaColor = Random.Range(1,4);   
        captchaPrompt = Random.Range(1,4);
        CreatePrompt(captchaColor,captchaPrompt);
    }
    private void CreatePrompt(int color,int prompt)
    {
        switch(color)
        {
            case 1: 
                captchaImage.color = Color.red; break;
            case 2: 
                captchaImage.color = Color.green;break;
            case 3: 
                captchaImage.color = Color.blue; break;
        }
        switch (prompt)
        {
            case 1:
                promptEndText.text = "red"; promptEndText.color = Color.red;
                promptText.text = "This color is " + promptEndText.text; break;
            case 2:
                promptEndText.text = "green"; promptEndText.color = Color.green;
                promptText.text = "This color is " + promptEndText.text; break;
            case 3:
                promptEndText.text = "blue"; promptEndText.color = Color.blue;
                promptText.text = "This color is " + promptEndText.text; break;
        }
    }
    /// <summary>
    /// Handles logic for the yes and no buttons 
    /// </summary>
    public void YesButton()
    {
        if(captchaColor == captchaPrompt)
        {
            Correct();
        }
        else
        {
            print("Try again");
        }
    }
    public void NoButton()
    {
        if (captchaColor != captchaPrompt)
        {
            Correct();
        }
        else
        {
            print("Try again");
        }
    }

    private void Correct()
    {
        if(currentQuestion < maxQuestions)
        {
            print("Correct");
            SetUpFirstCaptcha();
            currentQuestion++;
        }
        else
        {
            EndCaptcha();
        }
    }
    public void EndCaptcha()
    {
        captchaGO.SetActive(false);
        cycle.StartCaptcha();   
    }
}
