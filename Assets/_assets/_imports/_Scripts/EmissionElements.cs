using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionElements : MonoBehaviour
{
    float timer;
    float timeLimit;

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;

        timeLimit = 4.0f;
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {            
            timer = 0f;
        }

        float emission = Mathf.PingPong(timer, 2.0f);
        Color baseColor = new Color (255f, 100f, 0f); //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission / 1000);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
