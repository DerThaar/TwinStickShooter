using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingTest : MonoBehaviour
{
	float maxForce = 1;
	[SerializeField] float maxSpeed = 1;
	[SerializeField] float MaxSlowDistance = 10f;
	
	Vector3 velocity;	
	Transform target;
	

	void Awake()
	{
		velocity = Vector3.zero;
		target = GameObject.Find("Sphere").transform;
	}


	void Update()
	{		
		Arrive();		
	}	

	void Arrive()
	{
		Vector3 desired = target.position - transform.position;
		desired -= desired.normalized * 1.5f;
		float distanceToTarget = desired.magnitude;

		if (distanceToTarget < MaxSlowDistance)
		{
			float mappedSpeed = Mathe.Map(distanceToTarget, 0, MaxSlowDistance, 0, maxSpeed);
			desired = desired.normalized * mappedSpeed;
		}
		else
		{
			desired = desired.normalized * maxSpeed;
		}

		Vector3 steering = desired - velocity;
		steering = Vector3.ClampMagnitude(steering, maxForce);
		ApplyForce(steering);
	}

	void ApplyForce(Vector3 steering)
	{
		velocity += steering;
		transform.Translate(velocity * Time.deltaTime);
	}
}
