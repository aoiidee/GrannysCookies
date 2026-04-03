using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Analytics.IAnalytic;

public class EndLineScript : MonoBehaviour
{
    [SerializeField] private Vector2 lineStart;
    [SerializeField] private float distance;
    private PopupFunctions p;
    private void Start()
    {
        p = FindAnyObjectByType<PopupFunctions>();
    }
    private void EndGame()
    {
        print("Done");
        try
        {
            GameObject.FindAnyObjectByType<GrannyText>().DisplayDialogue();
            p.lastGame = true;
            PopupFunctions.Instance.KillScene(gameObject);
        }
        catch
        {
            p.KillScene(gameObject);
            Debug.LogWarning("Unable to find Popupfunctions!");
        }
    }
    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(lineStart, Vector2.right,distance);
        if (hit.collider != null)
        {
            if(hit.collider.gameObject.layer == 6 || hit.collider.gameObject.layer == 9)
            {
                if (hit.collider.tag == "ValidBlock")
                {
                    EndGame();
                }
            }            
        }
    }
}
