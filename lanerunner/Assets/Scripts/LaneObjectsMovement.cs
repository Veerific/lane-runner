using Codice.CM.Common.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneObjectsMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed;




    public void Reset()
    {
        speed.z = 0.001f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= speed;
        speed.z += 0.0004f;
    
    }

}
