using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour
{
    [Header("Key Component")]
    public bool isCollected;
    public bool isInRange;
    public bool ActivateJumpScare;
    public GameObject InteractUI;
    public GameObject Key;
    public AudioSource PickingUpSound;


    void Start()
    {
        isCollected = false;
        InteractUI.SetActive(false);
        isInRange = false;
    }

    void Update()
    {
        CollectKey();
    }

    //Box Colliders stuff
    private void OnTriggerEnter(Collider other)
    {
        InteractUI.SetActive(true);
        isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        InteractUI.SetActive(false);    
        isInRange= false;
    }

    public void CollectKey()
    {
        if (isInRange && !isCollected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                isCollected= true;
                PickingUpSound.Play();
                InteractUI.SetActive(false);
                Key.SetActive(false);
            }
        }
    }
}
