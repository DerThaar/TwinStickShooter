using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float movePower = 2;
    [SerializeField] private float moveVelocity = 10;

    private Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().maxAngularVelocity = moveVelocity;
    }


    public void Move(Vector3 moveDirection)
    {
        rBody.AddForce(moveDirection * movePower);
    }
}
