using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicle : MonoBehaviour
{
	public Vector3 Velocity { get; set; }

	public SteeringBehaviour[] SteeringBehaviours;


	void Awake()
	{
		SteeringBehaviours = GetComponents<SteeringBehaviour>();
	}

	public void ApplyForce(Vector3 sForce)
	{
		Velocity += sForce;
	}

	public void UpdateVehicle()
	{
		transform.position += Velocity * Time.deltaTime;
	}
}
