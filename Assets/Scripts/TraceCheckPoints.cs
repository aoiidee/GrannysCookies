using UnityEngine;
using UnityEngine.UI;

public class TraceCheckPoints : MonoBehaviour
{
    [SerializeField] private GameObject[] checkPoints;
    private GameObject nextCheckPoint;
    private int i;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        i = 0;
        nextCheckPoint = checkPoints[i];    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CheckPoint")
        {
            if(collision.gameObject == nextCheckPoint)
            {
                nextCheckPoint.GetComponent<Image>().color = Color.green;
                if (i >= 3)
                {
                    i = 4;
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
    private void EndCaptcha()
    {
        FindAnyObjectByType<PopupFunctions>().KillScene(gameObject);
    }
}
