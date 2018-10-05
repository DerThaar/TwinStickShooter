using UnityEngine;

public class Separation : SteeringBehaviour
{
	[SerializeField] float separationDistance = 2f;

	AI ai;


	public override void Awake()
	{
		base.Awake();
		ai = FindObjectOfType<AI>();
	}

	public override void Steer()
	{
		Vector3 averageDir = Vector3.zero;
		int numberOfCloseVehicles = 0;

		for (int i = 0; i < ai.EnemyVehicles.Count; i++)
		{
			Vector3 direction = transform.position - ai.EnemyVehicles[i].transform.position;
			if(direction.sqrMagnitude < (separationDistance * separationDistance) && direction.sqrMagnitude > 0.00001f)
			{
				numberOfCloseVehicles++;
				averageDir += direction.normalized;
			}
		}

		if (numberOfCloseVehicles > 0)
		{
			averageDir = averageDir / numberOfCloseVehicles; 
		}
		else
		{
			return;
		}

		Vector3 desired = averageDir * maxSpeed;
		Vector3 steeringForce = desired - vehicle.Velocity;
		steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
		vehicle.ApplyForce(steeringForce);		
	}	
}
