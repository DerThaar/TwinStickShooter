using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopScript : MonoBehaviour
{
    public GameObject sphere;



    void Update()
    {
        float x = sphere.transform.position.x;
        float y = sphere.transform.position.y;
        float z = sphere.transform.position.z;
      
        transform.position = new Vector3(x, y + 0.5f, z);
    }
}
