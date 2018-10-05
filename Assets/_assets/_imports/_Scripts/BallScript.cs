using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class BallScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 move;
    private Vector3 camForward;
    private Transform cam;
   
    void Awake()
    {       

        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("No Main Camera found!");
        }
    }   

    void Update()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        if (cam != null)
        {
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1).normalized);
            move = (v * camForward + h * cam.right).normalized;
        }
        else
        {
            move = (v * Vector3.forward + h * Vector3.right).normalized;
        }
    }
    private void FixedUpdate()
    {
       player.GetComponent<BallBehaviour>().Move(move);
    }
}
