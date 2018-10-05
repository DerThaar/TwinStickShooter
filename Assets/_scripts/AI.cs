using UnityEngine;
using System.Collections.Generic;

public class AI : MonoBehaviour
{
	[SerializeField]
	GameObject defaultEnemy;
	public EnemyPool defaultEnemyPool;
	public List<EnemyVehicle> EnemyVehicles = new List<EnemyVehicle>(32);


	void Awake()
	{
		defaultEnemyPool = new EnemyPool(defaultEnemy);
		defaultEnemyPool.InitializePool();
	}

	void Update()
	{
		for (int i = 0; i < EnemyVehicles.Count; i++)
		{
			EnemyVehicle eV = EnemyVehicles[i];

			for (int j = 0; j < eV.SteeringBehaviours.Length; j++)
			{
				eV.SteeringBehaviours[j].Steer();
			}

			eV.UpdateVehicle();
		}
	}

	public void Spawn(List<Vector3> positions)
	{
		for (int i = 0; i < positions.Count; i++)
		{					
			EnemyVehicles.Add(defaultEnemyPool.GetNext(positions[i]).GetComponent<EnemyVehicle>());
		}
	}
}


public class EnemyPool
{
	GameObject prefab; //this.prefab
	public Stack<GameObject> enemies = new Stack<GameObject>(16);

	public EnemyPool(GameObject prefab)
	{
		this.prefab = prefab;
	}

	public void InitializePool()
	{
		for (int i = 0; i < 16; i++)
		{
			GameObject enemy = GameObject.Instantiate(prefab);
			enemies.Push(enemy);
		}
	}

	public GameObject GetNext(Vector3 atPosition)
	{
		if(enemies.Count == 0)
		{
			return null;
		}
		else
		{
			GameObject enemy = enemies.Pop();
			enemy.transform.position = atPosition;
			enemy.SetActive(true);
			return enemy;
		}
	}

	public void ReturnToPool(GameObject enemy)
	{
		enemy.SetActive(false);
		enemy.transform.position = Vector3.zero;
		enemies.Push(enemy);
	}
}