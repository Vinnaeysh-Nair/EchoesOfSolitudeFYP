using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSuddenStatic : MonoBehaviour
{
    StaticScript staticScript;
    public AudioSource RunningEntitySound;
    private void Start()
    {
        this.gameObject.SetActive(false);
        staticScript = FindObjectOfType<StaticScript>();
    }

    public void TestDetection()
    { 
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        staticScript.SuddenStatic();
        RunningEntitySound.Play();
        StartCoroutine(RemoveObject());
    }


    IEnumerator RemoveObject()
    {
        this.GetComponent<Collider>().enabled = false;
        yield return new WaitUntil(()=> !RunningEntitySound.isPlaying);
        this.gameObject.SetActive(false);
    }
}
