using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float score;
    public int itemCount;

    private void Start()
    {
        itemCount = 0;
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            score += 1000;
            itemCount++;
            other.gameObject.SetActive(false);
        }
    }
}
