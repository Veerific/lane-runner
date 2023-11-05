using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{

    public UnityEvent playerMovesLeft, playerMovesRight, playerJumps;
    

    void Start()
    {
        if(playerMovesLeft == null) playerMovesLeft = new UnityEvent();
        if (playerMovesRight == null) playerMovesRight = new UnityEvent();
        if (playerJumps == null) playerJumps = new UnityEvent();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            playerMovesLeft.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerMovesRight.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerJumps.Invoke();
        }
    }
}
