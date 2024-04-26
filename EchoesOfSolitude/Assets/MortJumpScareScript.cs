using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortJumpScareScript : MonoBehaviour
{
    public GameObject DemolishedObjects;
    public GameObject NormalObjects;
    public AudioSource JmpScareSound;
    public bool isJumpScared;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        DemolishedObjects.SetActive(false);
        NormalObjects.SetActive(true);
        isJumpScared = false;
    }

    private void Update()
    {
        JmpScareSound.Play();
        if (isJumpScared)
        {
            DemolishedObjects.SetActive(true);
            NormalObjects.SetActive(false);
            //RunningJumpScare.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isJumpScared = true;
        this.GetComponent<Collider>().enabled = false;
    }
}
