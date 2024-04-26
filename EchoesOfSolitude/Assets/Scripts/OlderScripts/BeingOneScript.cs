using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingOneScript : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource Suspense;

    void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void CallIdleFunc()
    {
        this.gameObject.SetActive(true);
        Suspense.Play();
    }
}
