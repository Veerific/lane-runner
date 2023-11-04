using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject laneLeft, laneMiddle, laneRight;
    private int currentPlayerPos;

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
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            print("aa");
            print(currentPlayerPos);
            currentPlayerPos = currentPlayerPos > 0 ? currentPlayerPos-=1: 0;
        }

        if (Input.GetKeyDown(KeyCode.D)){
            print("aaa");
            print(currentPlayerPos);
            currentPlayerPos = currentPlayerPos < 2 ? currentPlayerPos+=1 : 2;
        }
    }
}
