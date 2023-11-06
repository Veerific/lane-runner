using Codice.CM.Common.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaneObjectsMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed;
    private bool gameOver = false;
    public float distance;

    public void Reset()
    {
        speed.z = 0.001f;
    }
    public void GameOver()
    {
        gameOver = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameOver)
        {
            transform.position -= speed;
            speed.z += 0.0007f;
        }
    }

    private void Update()
    {
        distance = -transform.position.z;
    }
}
