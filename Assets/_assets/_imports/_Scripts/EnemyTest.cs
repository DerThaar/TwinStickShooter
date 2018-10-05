using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
	AI ai;

	float timer;
	float random;

	void Start()
	{
		ai = FindObjectOfType<AI>(); //Nur zu Testzwecken, weil langsam
		random = Random.Range(0.5f, 6f);
	}
	void Update()
	{
		timer += Time.deltaTime;

		if (timer > random)
		{
			ai.defaultEnemyPool.ReturnToPool(gameObject);
			timer = 0f;
		}
	}
}
