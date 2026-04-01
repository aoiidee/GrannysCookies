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
    [SerializeField] private GameObject catDogQuestion, foodMasterQuestion, wolfGrandmaQuestion;
    [SerializeField] private int currentQuestion;

    [SerializeField] private Animator _captchaPanelAnim;
    [SerializeField] private YesButton _yB;
    [SerializeField] private NoButton _nB;

    private CaptchaCycle cycle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cycle = GameObject.FindFirstObjectByType<CaptchaCycle>();
        currentQuestion = 1;
    }
    /// <summary>
    /// Created both the prompt and selects the image color
    /// </summary>
    public void SetUpFirstCaptcha()
    {
        switch(currentQuestion)
        {
            case 1: catDogQuestion.SetActive(true);
                foodMasterQuestion.SetActive(false);
                wolfGrandmaQuestion.SetActive(false);
                _captchaPanelAnim.Play("CaptchaWindowBloop");
                _yB.SetButtonCorrect(false);
                _nB.SetButtonCorrect(true); break;
            case 2: foodMasterQuestion.SetActive(true);
                catDogQuestion.SetActive(false);
                wolfGrandmaQuestion.SetActive(false);
                _captchaPanelAnim.Play("CaptchaWindowBloop");
                _yB.SetButtonCorrect(true);
                _nB.SetButtonCorrect(false); break;
            case 3: wolfGrandmaQuestion.SetActive(true);
                catDogQuestion.SetActive(false);
                foodMasterQuestion.SetActive(false);
                _captchaPanelAnim.Play("CaptchaWindowBloop2");
                _yB.SetButtonCorrect(false);
                _nB.SetButtonCorrect(true); break; 

        }
    }
    /// <summary>
    /// Handles logic for the yes and no buttons 
    /// </summary>
    public void YesButton()
    {
        if(currentQuestion == 2)
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
        if (currentQuestion == 1 || currentQuestion == 3)
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
        if(currentQuestion < maxQuestions - 1)
        {
            print("Correct");
            currentQuestion++;
            SetUpFirstCaptcha();

        }
        else
        {
            EndCaptcha();
        }
    }
    public void EndCaptcha()
    {
        captchaGO.SetActive(false);
        //If you see errors for the below code, replace the browser game object in scene with the one in CamTest
        FindAnyObjectByType<BrowserAnims>().GetComponent<Animator>().Play("BrowserBackgroundStartup");
        currentQuestion = 0;
        try
        {
            FindAnyObjectByType<PopupFunctions>().KillScene(gameObject);
        }
        catch
        {
            cycle.StartRandomCaptcha();
        }
           
    }
}
