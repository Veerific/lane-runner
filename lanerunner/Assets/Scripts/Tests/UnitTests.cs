using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class UnitTests
{


    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayerMovemen_SwitchesLane()
    {
        GameObject lane = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Lanes"));
        GameObject player = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        Vector3 currentPos = player.transform.position;
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        playerInput.playerMovesLeft.Invoke();
        yield return new WaitForSeconds(0.1f);

        Assert.AreNotEqual(currentPos, player.transform.position);
    }
}
