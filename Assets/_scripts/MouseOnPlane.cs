using UnityEngine;

public class MouseOnPlane : MonoBehaviour
{
    public Transform planePrototype;

    Camera cam;
    Plane plane;

    void Awake()
    {
        cam = Camera.main;        
        plane = new Plane(planePrototype.up, planePrototype.position);
    }

    public Vector3 GetMousePointOnPlane()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float distance;
        if(plane.Raycast(ray, out distance))
        {
            Vector3 pointAlongPlane = ray.origin + (distance * ray.direction);
            return pointAlongPlane;
        }
        return Vector3.zero;
    }
}
