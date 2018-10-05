using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	BulletPool bulletpool;

	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Transform bulletSpawn;
	[SerializeField] float interval = 0.2f;

	float timer;


	void Awake()
	{
		bulletpool = new BulletPool(bulletPrefab);
		bulletpool.InitializePool();
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			timer = interval;
		}

		if (Input.GetButton("Fire1"))
		{
			timer += Time.deltaTime;
			if (timer >= interval)
			{
				Shoot();
				timer = 0f;
			}
		}
	}

	void Shoot()
	{
		bulletpool.GetNext(bulletSpawn.position, bulletSpawn.rotation);
	}
}

public class BulletPool
{
	GameObject prefab; //this.prefab
	public Stack<GameObject> bullets = new Stack<GameObject>(16);

	public BulletPool(GameObject prefab)
	{
		this.prefab = prefab;
	}

	public void InitializePool()
	{
		for (int i = 0; i < 16; i++)
		{
			GameObject bullet = GameObject.Instantiate(prefab);
			bullet.GetComponent<Bullet>().MyPool = this;
			bullets.Push(bullet);
		}
	}

	public GameObject GetNext(Vector3 atPosition, Quaternion withRotation)
	{
		GameObject bullet;
		if (bullets.Count == 0)
		{
			bullet = GameObject.Instantiate(prefab);
			bullet.GetComponent<Bullet>().MyPool = this;
		}
		else
		{
			bullet = bullets.Pop();
		}
		bullet.transform.position = atPosition;
		bullet.transform.rotation = withRotation;
		bullet.SetActive(true);
		return bullet;
	}

	public void ReturnToPool(GameObject bullet)
	{
		bullet.SetActive(false);
		bullet.transform.position = Vector3.zero;
		bullets.Push(bullet);
	}
}
