using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] float speed = 40f;
	[SerializeField] LayerMask layerMask;
	[SerializeField] float sleepTime = 5f;
	[SerializeField] GameObject particle;
	float sleepTimer;
	BulletPool myPool;
	public BulletPool MyPool { set { myPool = value; } }

	void Update()
	{
		sleepTimer += Time.deltaTime;
		if(sleepTimer > sleepTime)
		{
			sleepTimer = 0;
			myPool.ReturnToPool(gameObject);
		}
		Vector3 prevPos = transform.position;
		transform.position += transform.forward * Time.deltaTime * speed;
		Vector3 dir = transform.position - prevPos;
		Ray ray = new Ray(prevPos, dir);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, dir.magnitude, layerMask))
		{
			Collide(hit.collider);			
		}
	}

	void Collide(Collider col)
	{
		sleepTimer = 0;
		if (col.gameObject.tag == "Enemy")
		{
			GameObject.Instantiate(particle, col.gameObject.transform.position, Quaternion.identity);
			FindObjectOfType<AI>().defaultEnemyPool.ReturnToPool(col.gameObject);
		}
		myPool.ReturnToPool(gameObject);

	}
}
