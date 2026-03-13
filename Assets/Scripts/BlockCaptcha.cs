using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BlockCaptcha : MonoBehaviour
{
    [SerializeField] private GameObject blockGO;
    [SerializeField] private GameObject captchaGO;
    [SerializeField] private int blockDistance;
    [SerializeField] private int greenBlockAmt;
    private CaptchaCycle cycle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         cycle = GameObject.FindFirstObjectByType<CaptchaCycle>();  
    }
    public void AddGreens()
    {
        GameObject[] blockList = GameObject.FindGameObjectsWithTag("RedButton");

        int button1 = Random.Range(0, 3);
        int button2 = Random.Range(3,6);
        int button3 = Random.Range(6,9);

        CreateGreenButtons(blockList[button1]);
        CreateGreenButtons(blockList[button2]);
        CreateGreenButtons(blockList[button3]);
    }
    private void CreateGreenButtons(GameObject g)
    {
        g.GetComponent<Image>().sprite = g.GetComponent<ButtonSprite>().clickedSprite;    
        g.gameObject.tag = "GreenButton";
    }
    public void MakeButtonsGreen(GameObject b)
    {
        if(b.tag == "RedButton")
        {
            b.GetComponent<Image>().sprite = b.GetComponent<ButtonSprite>().clickedSprite;
            b.gameObject.tag = "GreenButton";
            greenBlockAmt++;    
            if(greenBlockAmt >= 12)
            {
                EndCaptcha();  
            }
        }
        else if(b.tag == "GreenButton")
        {
            b.GetComponent<Image>().sprite = b.GetComponent<ButtonSprite>().unClickedSprite;
            b.gameObject.tag = "RedButton";
            greenBlockAmt--;    
        }
    }
    public void SetUpBlocks()
    {
        GameObject[] blockList = GameObject.FindGameObjectsWithTag("GreenButton");
        foreach(GameObject g in blockList)
        {
            g.GetComponent<Image>().sprite = g.GetComponent<ButtonSprite>().unClickedSprite;
            g.gameObject.tag = "RedButton";
        }
        greenBlockAmt = 3;
        AddGreens();
    }
    private void EndCaptcha()
    {
        captchaGO.SetActive(false);
        //SetUpBlocks();  
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
