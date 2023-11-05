using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject laneLeft, laneMiddle, laneRight;
    [HideInInspector]
    public int currentPlayerPos;   
    private bool isJumping;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpVelocity;

    [SerializeField] private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPos = 1;
        playerInput.playerMovesLeft.AddListener(MoveLeft);
        playerInput.playerMovesRight.AddListener(MoveRight);
        playerInput.playerJumps.AddListener(Jump);
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

    public void MoveLeft()
    {
        currentPlayerPos = currentPlayerPos > 0 ? currentPlayerPos -= 1 : 0;
    }

    private void MoveRight()
    {
        currentPlayerPos = currentPlayerPos < 2 ? currentPlayerPos += 1 : 2;
    }

    private void Jump()
    {
        isJumping = true;
    }


}
