using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSwapScript : MonoBehaviour
{
    public GameObject[] NormalPhotos;
    public GameObject[] CreepyPhotos;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var nPhoto in NormalPhotos)
        { 
            nPhoto.gameObject.SetActive(true);
        }

        foreach (var cPhoto in CreepyPhotos)
        {
            cPhoto.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var nPhoto in NormalPhotos)
        {
            nPhoto.gameObject.SetActive(false);
        }

        foreach (var cPhoto in CreepyPhotos)
        {
            cPhoto.gameObject.SetActive(true);
        }
    }
}
