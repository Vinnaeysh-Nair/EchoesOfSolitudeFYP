using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;
public class NoteBook1 : MonoBehaviour
{
    public GameObject NoteUI;
    public GameObject NoteBook;
    public GameObject EtoEnableUI;
    public GameObject Recticle;
    public GameObject ObjectivesUI;
    public bool pLayerDetected;
    public bool isRead;
    public bool ObjectiveCompleted;
    public bool isReadAudio;
    public string ObjectiveID = "";
    public AudioSource bookSound;

    [Header("EventSystems")]
    public UnityEvent SuddenStaticJitter;

    // Start is called before the first frame update
    void Start()
    {
        EtoEnableUI.SetActive(false);
        NoteUI.SetActive(false);
        pLayerDetected = false;
        isRead = false;
        ObjectiveCompleted = false;
        isReadAudio = false;
    }

    private void Update()
    {
        ReadFunc();
    }

    private void OnTriggerEnter(Collider other)
    {
        pLayerDetected = true;
        EtoEnableUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        pLayerDetected = false;
        EtoEnableUI.SetActive(false);
    }

    void ReadFunc()
    {
        if (pLayerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isRead = !isRead;
                EtoEnableUI.SetActive(false);
                NoteUI.SetActive(isRead);
                Recticle.SetActive(!isRead);
                bookSound.Play();

                if (!isRead)
                {
                    NoteBook.SetActive(false);
                    isReadAudio = true;
                    SuddenStaticJitter.Invoke();
                }
            }
        }
    }
}

