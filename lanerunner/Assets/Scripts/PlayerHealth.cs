using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    [HideInInspector]
    public bool isDead;
    [SerializeField]
    public LaneObjectsMovement objMovement;
    [SerializeField]
    ResetScene reset;
    [SerializeField]
    private TextMeshProUGUI healthText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) DecreaseHealth();
        healthText.text = "Health: " + health.ToString();
    }

    public void DecreaseHealth()
    {
        
        health--;
        if(health <= 0) { GameOver(); }
    }

    public void GameOver()
    {
        isDead = true;
        objMovement.GameOver();
        reset.Reset();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle" && !isDead)
        {
            other.gameObject.SetActive(false);
            DecreaseHealth();
            objMovement.Reset();
          
        }
    }


}
