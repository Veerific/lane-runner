using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float score;
    private float scoreIncrement;

    private void Start()
    {
        score = 1;
        scoreIncrement = 1.001f;
    }

    // Update is called once per frame
    void Update()
    {
        score += (1 * scoreIncrement);
        scoreIncrement += 0.007f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            score += 1000;
            other.gameObject.SetActive(false);
        }
    }
}
