﻿using UnityEngine;
using System.Collections;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 6.0F;   
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;            
        }
        else
        {
            moveDirection.x = 0f;
            moveDirection.z = 0f;
        }
        moveDirection.y -= gravity * Time.deltaTime;        
        controller.Move(moveDirection * Time.deltaTime);
    }
}