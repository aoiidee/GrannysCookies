using UnityEngine;
using UnityEngine.Rendering;

public class DuckScript : MonoBehaviour
{
    public Rigidbody2D rb;

   
    [SerializeField] private float minUpForce;
    [SerializeField] private float maxUpForce;
    [SerializeField] private GameObject duck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce (new Vector3 (0, Random.Range(minUpForce, maxUpForce) ,0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(duck.transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }
    }
    void OnMouseDown()
    {
        Destroy (this.gameObject);
        Debug.Log("Clicked");
    }
}
