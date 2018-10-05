using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionStage : MonoBehaviour
{
    Color newColor = Color.yellow;
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
            newColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            timer = 0f;
        }

        float emission = Mathf.PingPong(timer, 2.0f);
        Color baseColor = newColor; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission * 7);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
