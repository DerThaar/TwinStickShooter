using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownTrigger : MonoBehaviour
{    
    public GameObject spawn;
    Vector3 startPos;

    private void Awake()
    {
        startPos = spawn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = startPos;

    }
}
