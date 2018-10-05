using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 100f;
    public float acceleration = 10f;
    public float friction = 10f;
    public Transform body;
    MouseOnPlane mouseOnPlane;
    Vector3 moveVector;
    Vector3 velocity;

    private void Start()
    {
        mouseOnPlane = GetComponent<MouseOnPlane>();
        velocity = Vector3.zero;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //Destroy(gameObject);
    }

    void Update()
    {
        Move();
        RotateBody();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
        }
    }

    void RotateBody()
    {
        //body.Rotate(0f, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0f);
        Vector3 mouseDirection = mouseOnPlane.GetMousePointOnPlane() - transform.position;
        body.rotation = Quaternion.LookRotation(mouseDirection, body.up);
    }

    void Move()
    {
        Vector3 moveX = Vector3.right * Input.GetAxis("Horizontal");
        Vector3 moveZ = Vector3.forward * Input.GetAxis("Vertical");
        moveVector = moveX + moveZ;
        velocity += moveVector * acceleration * Time.deltaTime;
        transform.position += velocity * speed * Time.deltaTime;
        velocity -= friction * Time.deltaTime * velocity;
    }
}
