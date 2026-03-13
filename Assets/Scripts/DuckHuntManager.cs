using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class DuckHuntManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnOffset;

    [SerializeField] public int duckScore;
    [SerializeField] private int reqScore;
    [SerializeField] private int filler;

    [SerializeField] private GameObject cookie;

    private Vector2 adjustedMouseClickPos = Vector2.zero;

    [SerializeField] private Camera c;

    public static Action<Vector2> DuckClick;

    

    public Vector2 AdjustedMouseClickPos { get => adjustedMouseClickPos; set => adjustedMouseClickPos = value; }

    public void AdjustedClick(Vector2 pos)
    {
        Vector2 testPos = c.ScreenToWorldPoint(pos * new Vector2(c.pixelWidth, c.pixelHeight));
        adjustedMouseClickPos = testPos;
        DuckClick?.Invoke(adjustedMouseClickPos);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        duckScore = 0;
        filler = 0;
        StartCoroutine(Spawn());
    }

    //spawns the ducks randomly based off spawnRate, SpawnOffset, and spawnPoint and stops once score is >= reqScore
    private IEnumerator Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            i = filler;
            
            GameObject newCookie = Instantiate(cookie, new Vector3(transform.position.x+2+UnityEngine.Random.Range(0,spawnOffset), transform.position.y), Quaternion.identity);
            Debug.Log("Spawning duck");
            //newCookie.transform.SetParent(transform, false);


            yield return new WaitForSeconds(spawnRate);

        }
    }
    //checks if reqScore has been obtained
    void Update()
    {
        if (duckScore >= reqScore)
        {
            GameObject.FindAnyObjectByType<GrannyText>().DisplayDialogue();
            filler = 100;
           
            Destroy(gameManager.gameObject);
        }
    }
    public void AddScore()
    {
        duckScore++;
    }
}
