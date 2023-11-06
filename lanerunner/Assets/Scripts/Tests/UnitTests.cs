using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public class UnitTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayerMovement_SwitchesToLeftLaneCorrectly()
    {
        GameObject sceneObjects = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SceneObjects"));

        yield return new WaitUntil(() => sceneObjects != null);

        GameObject player = sceneObjects.transform.Find("Player").gameObject;
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        GameObject leftLane = sceneObjects.transform.Find("Left").gameObject;
        

        playerInput.playerMovesLeft.Invoke();
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(leftLane.transform.position.x, player.transform.position.x);


        Object.Destroy(sceneObjects);
    }

    [UnityTest]
    public IEnumerator PlayerMovement_SwitchesToRightLaneCorrectly()
    {
        GameObject sceneObjects = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SceneObjects"));

        yield return new WaitUntil(() => sceneObjects != null);
        GameObject player = sceneObjects.transform.Find("Player").gameObject;
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        GameObject rightLane = sceneObjects.transform.Find("Right").gameObject;
 
        playerInput.playerMovesRight.Invoke();
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(rightLane.transform.position.x, player.transform.position.x);

        Object.Destroy(sceneObjects);
    }

    [UnityTest]
    public IEnumerator PlayerMovement_DoesntGoOutOfBoundsLeft()
    {
        GameObject sceneObjects = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SceneObjects"));

        yield return new WaitUntil(() => sceneObjects != null);

        GameObject player = sceneObjects.transform.Find("Player").gameObject;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        playerInput.playerMovesLeft.Invoke();
        playerInput.playerMovesLeft.Invoke();

        yield return new WaitForSeconds(0.3f);

        Assert.AreEqual(0, playerMovement.currentPlayerPos);
        Object.Destroy(sceneObjects);
    }
    [UnityTest]
    public IEnumerator PlayerMovement_DoesntGoOutOfBoundsRight()
    {
        GameObject sceneObjects = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SceneObjects"));

        yield return new WaitUntil(() => sceneObjects != null);

        GameObject player = sceneObjects.transform.Find("Player").gameObject;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        playerInput.playerMovesRight.Invoke();
        playerInput.playerMovesRight.Invoke();

        yield return new WaitForSeconds(0.3f);

        Assert.AreEqual(2, playerMovement.currentPlayerPos);
        Object.Destroy(sceneObjects);
    }


    [UnityTest]
    public IEnumerator PlayerHealth_GameOverIsCalledWhenHitThreeTimes()
    {
        GameObject sceneObjects = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SceneObjects"));
        GameObject level = Object.Instantiate(Resources.Load<GameObject>("Prefabs/LevelPreset"));
        

        yield return new WaitUntil(() => sceneObjects != null);

        GameObject player = sceneObjects.transform.Find("Player").gameObject;
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.objMovement = level.gameObject.GetComponent<LaneObjectsMovement>();

        playerInput.playerMovesRight.Invoke();

        yield return new WaitForSeconds(3f);

        playerInput.playerMovesLeft.Invoke();
        playerInput.playerMovesLeft.Invoke();

        yield return new WaitForSeconds(3f);

        playerInput.playerMovesRight.Invoke();

        yield return new WaitForSeconds(3f); 

        Assert.IsTrue(health.isDead);
        Object.Destroy(sceneObjects);
        Object.Destroy(level);
    }

    [UnityTest]
    public IEnumerator PlayerHealth_HealthDecreasesWhenHit()
    {
        GameObject sceneObjects = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SceneObjects"));
        GameObject level = Object.Instantiate(Resources.Load<GameObject>("Prefabs/LevelPreset"));

        yield return new WaitUntil(() => sceneObjects != null);

        GameObject player = sceneObjects.transform.Find("Player").gameObject;
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.objMovement = level.gameObject.GetComponent<LaneObjectsMovement>();
        int observedHealth = health.health;

        playerInput.playerMovesRight.Invoke();

        yield return new WaitForSeconds(3f);

        Assert.AreNotEqual(observedHealth, health.health);
        Object.Destroy(sceneObjects);
        Object.Destroy(level);
    }

    [UnityTest]
    public IEnumerator PlayerScore_ScoreIncreasesWithItem()
    {
        GameObject sceneObjects = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SceneObjects"));
        GameObject level = Object.Instantiate(Resources.Load<GameObject>("Prefabs/LevelPreset"));

        yield return new WaitUntil(() => sceneObjects != null);

        GameObject player = sceneObjects.transform.Find("Player").gameObject;
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        yield return new WaitForSeconds(4f);
      
        playerInput.playerMovesLeft.Invoke();
        int currentScore = player.GetComponent<PlayerScore>().score;

        yield return new WaitForSeconds(1f);

        int difference = player.GetComponent<PlayerScore>().score - currentScore;
        Assert.IsTrue(difference > 1000);
        Object.Destroy(sceneObjects);
        Object.Destroy(level);
    }



}
