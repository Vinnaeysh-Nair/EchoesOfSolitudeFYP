using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Script : MonoBehaviour
{
    public GameObject DoorUILocked;
    public GameObject DoorUIUnlocked;
    public bool isLocked;
    public Animation OpenDoor;
    public GameObject Door;
    public string OpenDoorNameAnim;
    public KeyInteract keyinteract;
    public AudioSource DoorCreakSound;
    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        DoorUILocked.SetActive(false);
        DoorUIUnlocked.SetActive(false);
        OpenDoor = Door.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoorFunc();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (keyinteract.isCollected == false)
        {
            DoorUILocked.SetActive(true);
            isLocked = true;
        }
        else if (keyinteract.isCollected == true)
        {
            DoorUIUnlocked.SetActive(true);
            isLocked = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (keyinteract.isCollected == false)
        {
            DoorUILocked.SetActive(false);
            isLocked = true;
        }
        else if (keyinteract.isCollected == true)
        {
            DoorUIUnlocked.SetActive(false);
            isLocked = false;
        }
    }

    void OpenDoorFunc()
    {
        if (!isLocked && Input.GetKey(KeyCode.E))
        {

            DoorUIUnlocked.SetActive(false);
            DoorCreakSound.Play();
            //Door.SetActive(false);
            OpenDoor.Play(OpenDoorNameAnim);
            this.gameObject.SetActive(false);
        }
    }
}
