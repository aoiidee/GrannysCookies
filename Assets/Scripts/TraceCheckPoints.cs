using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TraceCheckPoints : MonoBehaviour
{
    [SerializeField] private GameObject[] checkPoints;
    [SerializeField] private GameObject captchaGO;
    private GameObject nextCheckPoint;
    private int i;
    private CaptchaCycle cycle;

    private string s;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cycle = GameObject.FindFirstObjectByType<CaptchaCycle>();   
        i = 0;
        nextCheckPoint = checkPoints[i];    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CheckPoint")
        {
            if(collision.gameObject == nextCheckPoint)
            {
                s = "LTCP" + (i + 1).ToString() + "ActivatedTransition";
                nextCheckPoint.GetComponent<Animator>().Play(s);
                if (i != 5)
                {
                    AudioManager.PlaySound("IconAsc");
                }
                else
                {
                    AudioManager.PlaySound("CorrectBell");
                }
                nextCheckPoint.GetComponent<Image>().color = Color.green;
                if (i >= 5)
                {
                    i = 6;
                    EndCaptcha();   
                }
                else
                {
                    i++;
                    nextCheckPoint = checkPoints[i];
                }
            }
        }
    }
    public void ReturnToCheckPoint()
    {
        if(i > 0)
        {
            transform.position = checkPoints[i - 1].transform.position;
        }
    }
    private void ResetCaptcha()
    {
        i = 0;
        nextCheckPoint = checkPoints[i];
        foreach (GameObject obj in checkPoints)
        {
            obj.GetComponent<Image>().color = Color.white;  
        }
        captchaGO.SetActive(false);
    }
    private void EndCaptcha()
    {
        ResetCaptcha(); 
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
