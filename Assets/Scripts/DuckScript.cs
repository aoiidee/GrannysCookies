using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class DuckScript : MonoBehaviour
{
    public Rigidbody2D rb;


    [SerializeField] private float minUpForce;
    [SerializeField] private float maxUpForce;
    [SerializeField] private GameObject duck;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private DuckHuntManager huntManager;
    private float startPos;

    private bool death;
    [SerializeField] private Animator _animBase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = duck.transform.position.y;
        huntManager = FindAnyObjectByType<DuckHuntManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0, Random.Range(minUpForce, maxUpForce), 0), ForceMode2D.Impulse);
        DuckHuntManager.DuckClick += ClickCheck;
    }

    // Update is called once per frame
    void Update()
    {
        if (duck.transform.position.y < startPos - 10)
        {
            Destroy(this.gameObject);
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            
        }
    }

    public void ClickCheck(Vector2 v)
    {
        //Vector2 worldPos = Camera.main.ScreenToWorldPoint(
        //Mouse.current.position.ReadValue()
        //);
        Vector2 worldPos = v;//huntManager.AdjustedMouseClickPos;
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        try
        {
            if (hit.collider != null && !death && gameObject == hit.collider.gameObject)
            {
                death = true;
                _animBase.Play("DuckVirusPop");
                rb.bodyType = RigidbodyType2D.Static;
                //AudioSource.PlayClipAtPoint(hitSound, transform.position);
                //huntManager.AddScore();
                //Destroy(hit.collider.gameObject);
            }
        }
        catch
        {
            Debug.Log("duck destroyed, ignoring");
        }
    }

    //called from an animation event
    public void PostDeathSequence()
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
        huntManager.AddScore();
        Destroy(gameObject);
    }
}


