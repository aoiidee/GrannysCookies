using UnityEngine;

public class FallingBlockLogic : MonoBehaviour
{
    public bool isFalling;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 9)
        {
            isFalling= false;
            gameObject.tag = "ValidBlock";
        }
        if(collision.gameObject.layer == 8 && gameObject.layer != 9)
        {
            Destroy(gameObject);    
        }
    }

}
