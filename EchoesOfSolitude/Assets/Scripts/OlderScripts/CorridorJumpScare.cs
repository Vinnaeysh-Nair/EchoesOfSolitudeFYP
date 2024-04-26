using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorJumpScare : MonoBehaviour
{
    public GameObject Before;
    public GameObject After;
    public GameObject DoorFallTrigger;
    public AudioSource ThingsFalling;
    // Start is called before the first frame update
    void Start()
    {
        Before.SetActive(true);
        After.SetActive(false);
        //DoorFallTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Before.SetActive(false);
        After.SetActive(true);
        //DoorFallTrigger.SetActive(true);
        ThingsFalling.Play();
    }
}
