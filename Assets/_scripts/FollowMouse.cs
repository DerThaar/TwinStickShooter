using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	public Transform planePrototype;

	Camera cam;
	Plane plane;

	void Awake()
	{
		cam = Camera.main;
		plane = new Plane(planePrototype.up, planePrototype.position);
	}

	void Update()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		float distance;

		if (plane.Raycast(ray, out distance))
		{			
			Vector3 pointAlongPlane = ray.origin + (distance * ray.direction);
			transform.position = pointAlongPlane;
		}
		else
		{
			transform.position = Vector3.zero;
		}
	}
}
