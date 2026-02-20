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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = duck.transform.position.y;
        huntManager = FindAnyObjectByType<DuckHuntManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0, Random.Range(minUpForce, maxUpForce), 0), ForceMode2D.Impulse);
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
            //Vector2 worldPos = Camera.main.ScreenToWorldPoint(
            //Mouse.current.position.ReadValue()
            //);
            Vector2 worldPos = huntManager.AdjustedMouseClickPos;
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
                huntManager.AddScore();
                Destroy(hit.collider.gameObject);
            }
        }
    }
}


