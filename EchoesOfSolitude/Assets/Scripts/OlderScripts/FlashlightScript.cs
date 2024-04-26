using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class FlashlightScript : MonoBehaviour
{
    public TextMeshProUGUI EtoInteract;
    [SerializeField] float FlashLightDist;
    public bool isFlashTrue;
    public bool isFlashCollected;
    public GameObject FlashLightPrefab1;
    public GameObject FlashLightPrefab2;
    //public GameObject LightPrefab;
    public string PlayerTag;
    public AudioSource pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        EtoInteract.enabled = false;
        FlashLightPrefab2.SetActive(false);
        isFlashTrue = false;
        isFlashCollected = false;
        //LightPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FlashLightFunc();
        FlashLightFar();
        if (isFlashCollected)
        {
            EtoInteract.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            isFlashTrue = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            isFlashTrue = false;
        }
    }

    void FlashLightFunc()
    {
        if (isFlashTrue)
        {
                EtoInteract.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                FlashLightPrefab1.SetActive(false);
                FlashLightPrefab2.SetActive(true);
                //LightPrefab.SetActive(true);
                isFlashCollected = true;
                pickUpSound.Play(); 
                // Disable the component so that Update() not called
                enabled = false;

                //ObjectivesManager.CompleteObjective("FLASH_COLLECT");
            }
        }
    }


    void FlashLightFar()
    {
        if (!isFlashTrue)
        {
            EtoInteract.enabled = false;
        }
    }
}
