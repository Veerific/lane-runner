using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) DecreaseHealth();
    }

    public void DecreaseHealth()
    {
        if (health <= 0) GameOver();
        health--;
    }

    public void GameOver()
    {
        print("Dead lmao");
    }


}
