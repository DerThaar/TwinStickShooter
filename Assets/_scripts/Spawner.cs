using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] AI ai;
	[SerializeField] GameObject wavePrefab;


	void Start()
	{
		SpawnWave(wavePrefab);
	}

	public void SpawnWave(GameObject wave)
	{
		int enemyCount = wavePrefab.transform.childCount;
		List<Vector3> enemyPositions = new List<Vector3>(enemyCount);

		foreach (Transform enemyPos in wavePrefab.transform)
		{
			enemyPositions.Add(enemyPos.position);
		}

		ai.Spawn(enemyPositions);
	}
}
