using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    private float timer = 3;
    private bool willReset = false;

    // Update is called once per frame
    void Update()
    {
        if(willReset) timer -= Time.deltaTime;
        if (timer <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Reset()
    {
        willReset = true;
    }
}
