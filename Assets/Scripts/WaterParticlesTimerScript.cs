using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticlesTimerScript : MonoBehaviour
{
    public Material dissolveMaterial;
    public float timingValue;
    private float timer = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        dissolveMaterial.SetFloat("Vector1_A4D01AFA", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += timingValue;
        dissolveMaterial.SetFloat("Vector1_A4D01AFA", timer);
    }

    private void OnDestroy()
    {
        dissolveMaterial.SetFloat("Vector1_A4D01AFA", 1);
    }
}

