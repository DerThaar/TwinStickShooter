using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
	Transform target;


	public override void Awake()
	{
		base.Awake();
		target = GameObject.Find("Player").transform; 
	}	

	public override void Steer()
	{
		Vector3 desired = target.position - transform.position;
		desired = desired.normalized * maxSpeed;
		Vector3 steeringForce = desired - vehicle.Velocity;
		steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
		vehicle.ApplyForce(steeringForce);
	}

	void ApplyForce(Vector3 sForce)
	{
		vehicle.Velocity += sForce;		
	}
}
