using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{

    float timer;
    float timeLimit;

    const float pulseRange = 3f;    
    const float pulseMinimum = 1f;

    void Update()
    {
        Light light = GetComponent<Light>();
        
        timeLimit = 4.0f;
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            timer = 0f;
        }

        light.intensity = pulseMinimum + Mathf.PingPong(timer, pulseRange - pulseMinimum);    
        
       
        
    }
}
