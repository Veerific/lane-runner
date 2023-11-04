using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject laneLeft, laneMiddle, laneRight;
    private int currentPlayerPos;
    private bool isJumping;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPos = 1;
    }

    private void FixedUpdate()
    {
        switch(currentPlayerPos)
        {
            case 0:
                transform.position = new(laneLeft.transform.position.x, transform.position.y, transform.position.z);
                break;
            case 1:
                transform.position = new(laneMiddle.transform.position.x, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new(laneRight.transform.position.x, transform.position.y, transform.position.z);
                break;
        }

        if(isJumping) { 
            rb.AddForce(Vector3.up * jumpVelocity);
            isJumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A)){
          
            currentPlayerPos = currentPlayerPos > 0 ? currentPlayerPos-=1: 0;
        }

        if (Input.GetKeyDown(KeyCode.D)){
            
            currentPlayerPos = currentPlayerPos < 2 ? currentPlayerPos+=1 : 2;
        }
        if(Input.GetKeyDown(KeyCode.W)) isJumping = true;
        
    }
}
