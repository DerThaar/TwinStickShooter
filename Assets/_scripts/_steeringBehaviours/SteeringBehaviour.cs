using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
	[SerializeField] protected float maxSpeed = 4f;
	[SerializeField] protected float maxForce = 1f;

	protected EnemyVehicle vehicle;


	public abstract void Steer();

	public virtual void Awake()
	{
		vehicle = GetComponent<EnemyVehicle>();
	}

}
