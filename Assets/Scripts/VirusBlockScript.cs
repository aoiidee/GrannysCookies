using UnityEngine;

public class VirusBlockScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int tickCount;
    private  DropBlocks dropBlocks; 
    void Start()
    {
        tickCount = 3;
        dropBlocks = GameObject.FindFirstObjectByType<DropBlocks>();    
    }

    public void Tick()
    {
        tickCount--;
        if(tickCount <= 0)
        {
            gameObject.SetActive(false);        
        }
    }
}
