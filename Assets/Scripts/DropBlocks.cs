using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropBlocks : MonoBehaviour
{
    [SerializeField] private GameObject stackingBlock;
    [SerializeField] private float dropperSpeed;
    [SerializeField] private Vector2 leftPoint;
    [SerializeField] private Vector2 rightPoint;
    [SerializeField] private float dropCoolDown;
    private InputAction drop;
    private bool canDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drop = InputSystem.actions.FindAction("Drop");
        canDrop = true;
    }
    private void DropBlock()
    {
        if(canDrop)
        {
            Instantiate(stackingBlock, transform.position, Quaternion.identity);
            canDrop = false;
            StartCoroutine(DropDelay());
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
