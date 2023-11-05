using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float score;
    private float scoreIncrement;
    private int itemCount;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI itemText;

    private void Start()
    {
        itemCount = 0;
        score = 1;
        scoreIncrement = 1.001f;
    }

    // Update is called once per frame
    void Update()
    {
        score++;
        scoreText.text = "Score: " + ((int)score).ToString();
        itemText.text = "Items Got: " + itemCount.ToString();

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
