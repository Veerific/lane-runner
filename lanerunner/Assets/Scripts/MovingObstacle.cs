using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    [SerializeField]
    private float leftPosition, rightPosition, speed;
    
    private bool moveLeft, moveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new(leftPosition, transform.position.y, transform.position.z), 
                speed * Time.deltaTime);
        }
        if (moveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new(rightPosition, transform.position.y, transform.position.z), 
                speed * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (transform.position.x == leftPosition)
        {
            moveLeft = false;
            moveRight = true;
        }
        if (transform.position.x == rightPosition)
        {
            moveRight = false;
            moveLeft = true;
        }
    }
}
