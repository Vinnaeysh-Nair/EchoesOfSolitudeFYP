using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOffTrigger : MonoBehaviour
{
    public GameObject LightsFlickerTrigger;
    [SerializeField] List<GameObject> LightsOffList = new List<GameObject>();
    public Material LightOffMat;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject lightObjects in LightsOffList)
        {
            lightObjects.transform.GetChild(0).gameObject.SetActive(false);
            LightsFlickerTrigger.SetActive(false);
            SwapMaterial();
            StartCoroutine(DeleteSelf());
        }
    }

    void SwapMaterial()
    {
        foreach (GameObject lightObjects in LightsOffList)
        {
            lightObjects.GetComponent<Renderer>().material = LightOffMat;
        }
    }

    IEnumerator DeleteSelf()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}


