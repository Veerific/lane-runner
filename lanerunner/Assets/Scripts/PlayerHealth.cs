using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    [HideInInspector]
    public bool isDead;
    [SerializeField]
    LaneObjectsMovement objMovement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) DecreaseHealth();
    }

    public void DecreaseHealth()
    {
        if (health <= 0) { GameOver(); return; }
        health--;
    }

    public void GameOver()
    {
        isDead = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle" && !isDead)
        {
            DecreaseHealth();
            objMovement.Reset();
            other.gameObject.SetActive(false);
        }
    }


}
