using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLightBlinking : MonoBehaviour
{
    public Light blinkingLight;
    public float minIntensity = 0.0f;
    public float maxIntensity = 1.0f;
    public float blinkSpeed = 1.0f;

    private float currentIntensity;
    private bool increasing = true;

    // Start is called before the first frame update
    void Start()
    {
        currentIntensity = blinkingLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        // Change the intensity over time
        currentIntensity += (increasing ? blinkSpeed : -blinkSpeed) * Time.deltaTime;

        // Clamp intensity within min and max range
        currentIntensity = Mathf.Clamp(currentIntensity, minIntensity, maxIntensity);

        // Apply the intensity to the light
        blinkingLight.intensity = currentIntensity;

        // Reverse direction when reaching the min or max intensity
        if (currentIntensity <= minIntensity || currentIntensity >= maxIntensity)
        {
            increasing = !increasing;
        }
    }
}
