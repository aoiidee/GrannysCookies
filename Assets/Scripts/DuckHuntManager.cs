using System.Collections;
using UnityEngine;

public class DuckHuntManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnOffset;

    [SerializeField] private int score;
    [SerializeField] private int reqScore;
    private int filler;

    [SerializeField] private GameObject cookie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        StartCoroutine(Spawn());
    }

    //spawns the ducks randomly based off spawnRate, SpawnOffset, and spawnPoint and stops once score is >= reqScore
    private IEnumerator Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            i = filler;
            
            Instantiate(cookie, new Vector3(transform.position.x+Random.Range(0,spawnOffset), transform.position.y), Quaternion.identity);


            yield return new WaitForSeconds(spawnRate);

        }
    }
    //checks id reqScore has been obtained
    void Update()
    {
        if (score >= reqScore)
        {
            filler = 100;
        }
    }
}
