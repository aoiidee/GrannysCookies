using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Analytics.IAnalytic;

public class EndLineScript : MonoBehaviour
{
    [SerializeField] private Vector2 lineStart;
    [SerializeField] private float distance; 
    private void EndGame()
    {
        print("Done");
    }
    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(lineStart, Vector2.right,distance);
        if (hit.collider != null && hit.collider.gameObject.layer == 6)
        {
            if(hit.collider.tag == "ValidBlock")
            {
               EndGame();   
            }
        }
    }
}
