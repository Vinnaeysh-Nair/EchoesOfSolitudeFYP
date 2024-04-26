using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTriggerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> LightsOffList = new List<GameObject>();
    [SerializeField] List<Light> LightsFlickerList = new List<Light>();
    public AudioSource LightsFlickerSound;
    public AudioSource LightsBgSound;
    public Material LightOffMat;
    public Material LightOnMat;
    public float flickerInterval = 1;
    public bool isFlicker;
    float timer;

    private void Start()
    {
        isFlicker = false;
    }

    private void OnTriggerEnter(Collider other)
    {
/*        foreach (GameObject lightObjects in LightsOffList) 
        {
            lightObjects.transform.GetChild(0).gameObject.SetActive(false);
            SwapMaterial();
            isFlicker = true;
        }*/
        isFlicker = true;
    }

    private void Update()
    {
        if (isFlicker)
        {
            FlickerLight();
        }
    }

    void SwapMaterial()
    {
            foreach(GameObject lightObjects in LightsOffList) 
            {
                lightObjects.GetComponent<Renderer>().material = LightOffMat;
            }
    }

    void FlickerLight()
    {
        foreach (Light lightflickObject in LightsFlickerList)
        {
            timer += Time.deltaTime;
            if (timer > flickerInterval)
            {
                lightflickObject.enabled = !lightflickObject.enabled;
                // Depending whether light is enabled or not...
                // set to LightOnMat if light is on
                // else set to LightOffMat if light is off
                // using ternary operator:
                // (condition) ? (logic if true) : (logic if false)
                lightflickObject.GetComponentInParent<MeshRenderer>().material =
                    lightflickObject.enabled ? LightOnMat : LightOffMat;
                
                timer -= flickerInterval;
            }
        }
    }
}
