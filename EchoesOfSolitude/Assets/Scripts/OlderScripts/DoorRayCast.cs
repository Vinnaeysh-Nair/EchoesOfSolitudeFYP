using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class DoorRayCast : MonoBehaviour
{
    public LayerMask Doormask;
    public Camera cam;
    public float rayDist;
    public GameObject DoorUILocked;
    public GameObject DoorUIUnlocked;
    public bool isLocked;
    public bool isOpeningDoor;
    public bool DoorOpened;
    public Animation OpenDoor;
    public GameObject Door;
    public string OpenDoorNameAnim;
    public KeyInteract keyinteract;

    [Header("EventSystems")]
    public UnityEvent FlickeringFlash;

    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        DoorUILocked.SetActive(false);
        DoorUIUnlocked.SetActive(false);
        OpenDoor = Door.GetComponent<Animation>();
        isOpeningDoor = false;
        DoorOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorRayFunc();
        
    }

    public void DoorRayFunc()
    {
        if (!isOpeningDoor)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDist, Doormask))
            {
                if (!keyinteract.isCollected)
                {
                    DoorUILocked.SetActive(true);
                    isLocked = true;
                }
                else if (keyinteract.isCollected)
                {
                    DoorUIUnlocked.SetActive(true);
                    isLocked = false;
                }
            }
            else
            {
                if (DoorUIUnlocked)
                {
                    DoorUIUnlocked.SetActive(false);
                }
                if (DoorUILocked)
                {
                    DoorUILocked.SetActive(false);
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.green);
        }

        OpenDoorFunc();
    }

    void OpenDoorFunc()
    {
        if (!isLocked && Input.GetKey(KeyCode.E) && !DoorOpened)
        {
            DoorUIUnlocked.SetActive(false);
            isOpeningDoor = true;
            DoorOpened = true;  
            OpenDoor.Play(OpenDoorNameAnim);
            //StartCoroutine(PlayJumpScareSound1());
        }
    }

/*    IEnumerator PlayJumpScareSound1()
    {
        yield return new WaitUntil(() => !OpenDoor.IsPlaying(OpenDoorNameAnim));

        FlickeringFlash.Invoke();
    }*/

}
