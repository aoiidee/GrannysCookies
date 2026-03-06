using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DropBlocks : MonoBehaviour
{
    [SerializeField] private GameObject stackingBlock;
    [SerializeField] private GameObject stackingBlockLong;
    [SerializeField] private GameObject stackingBlockLShape;
    [SerializeField] private GameObject dropBlockPrefab;
    [SerializeField] private GameObject virusBlock;
    [SerializeField] private GameObject virusBlockL;
    [SerializeField] private GameObject virusBlockLong;
    [SerializeField] private Image nextBlock;
    [SerializeField] private float dropperSpeed;
    [SerializeField] private Vector2 leftPoint;
    [SerializeField] private Vector2 rightPoint;
    [SerializeField] private float dropCoolDown;
    private GameObject current;
    private GameObject next;
    public List<GameObject> viruses;
    private InputAction drop;
    private bool canDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drop = InputSystem.actions.FindAction("Drop");
        viruses = new List<GameObject>();   
        GetNextBlock(); 
        canDrop = true;
    }
    private void DropBlock()
    {
        if(canDrop)
        {
            AudioManager.PlaySound("BlockPlace");
            GameObject temp = Instantiate(Currentblock(), transform.position, Quaternion.identity);
            temp.transform.parent = dropBlockPrefab.transform;
            TickDown(); 
            if(temp.layer == 9)
            {
                viruses.Add(temp);  
            }
            GetNextBlock(); 
            canDrop = false;
            StartCoroutine(DropDelay());
        }
    }
    private void TickDown()
    {
        if(viruses.Count > 0)
        {
            foreach (GameObject obj in viruses)
            {
                obj.GetComponent<VirusBlockScript>().Tick();
            }
        }
    }
    IEnumerator DropDelay()
    {
        yield return new WaitForSeconds(dropCoolDown);
        canDrop = true;
    }
    private void SwapSpeed()
    {
        dropperSpeed = -dropperSpeed;   
    }
    private GameObject Currentblock()
    {
        current = next;
        return current;  
    }
    private void GetNextBlock()
    {
        int choice = Random.Range(0, 6);    
        switch(choice)
        {
            case 0: next = stackingBlock;
                nextBlock.sprite = next.GetComponent<SpriteRenderer>().sprite;
                nextBlock.GetComponent<Image>().color = Color.white; break;
            case 1: next = stackingBlockLong;
                nextBlock.sprite = next.GetComponent<SpriteRenderer>().sprite;
                nextBlock.GetComponent<Image>().color = Color.white; break;
            case 2: next = stackingBlockLShape;
                nextBlock.sprite = next.GetComponent<SpriteRenderer>().sprite;
                nextBlock.GetComponent<Image>().color = Color.white; break;
            case 3: next = virusBlock;
                nextBlock.sprite = next.GetComponent<SpriteRenderer>().sprite;
                nextBlock.GetComponent<Image>().color = Color.purple; break;
            case 4: next = virusBlockLong;
                nextBlock.sprite = next.GetComponent<SpriteRenderer>().sprite;
                nextBlock.GetComponent<Image>().color = Color.purple; break;
            case 5: next = virusBlockL;
                nextBlock.sprite = next.GetComponent<SpriteRenderer>().sprite;
                nextBlock.GetComponent<Image>().color = Color.purple; break;
            default: next = stackingBlock; break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (drop.WasCompletedThisFrame())
        {
            DropBlock();    
        }
    }
    void FixedUpdate()
    {
        if(transform.position.x >= rightPoint.x)
        {
            SwapSpeed();
        }
        if (transform.position.x <= leftPoint.x)
        {
            SwapSpeed();
        }
        GetComponent<Rigidbody2D>().linearVelocityX = dropperSpeed;
    }
}
