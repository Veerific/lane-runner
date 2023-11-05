using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject laneLeft, laneMiddle, laneRight;
    private int currentPlayerPos;
    private bool isJumping;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpVelocity;

    [SerializeField] private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        FindLanes();
        currentPlayerPos = 1;
        playerInput.playerMovesLeft.AddListener(MoveLeft);
        playerInput.playerMovesRight.AddListener(MoveRight);
        playerInput.playerJumps.AddListener(Jump);
    }
    
    void FindLanes()
    {
        laneLeft = GameObject.Find("Left");
        laneMiddle = GameObject.Find("Middle");
        laneRight = GameObject.Find("Right");
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

    private void MoveLeft()
    {
        currentPlayerPos = currentPlayerPos > 0 ? currentPlayerPos -= 1 : 0;
    }

    private void MoveRight()
    {
        currentPlayerPos = currentPlayerPos < 2 ? currentPlayerPos += 1 : 0;
    }

    private void Jump()
    {
        isJumping = true;
    }


}
