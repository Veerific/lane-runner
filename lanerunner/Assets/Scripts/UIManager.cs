using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, distanceText, itemText, healthText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject LaneObjects;
    private PlayerScore score;
    private PlayerHealth health;
    private LaneObjectsMovement distance;
    
    // Start is called before the first frame update
    void Start()
    {
        score = player.GetComponent<PlayerScore>();
        health = player.GetComponent<PlayerHealth>();
        distance = LaneObjects.GetComponent<LaneObjectsMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Start();
        scoreText.text = "Score: " + score.score;
        healthText.text = "Health: " + health.health;
        itemText.text = "Items Got: " + score.itemCount;
        distanceText.text = "Distance run: " + (int)distance.distance;
    }
}
