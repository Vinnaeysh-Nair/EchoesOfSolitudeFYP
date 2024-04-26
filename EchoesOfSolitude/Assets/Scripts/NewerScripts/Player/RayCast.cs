using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class RayCast : MonoBehaviour
{
    [Header("Camera")]
    public Camera Cam;

    [Header("RayStuff")]
    public float rayDist;

    [Header("DoorRay")]
    public LayerMask Doorlayer;
    public string DoorTag;
    private GameObject[] Door;

    [Header("LockedDoorRay")]
    public LayerMask LockedDoorLayer;
    public TextMeshProUGUI DoorLockedText;

    [Header("FinalDoorRay")]
    public LayerMask FinalDoorlayer;

    [Header("Interactables")]
    public LayerMask InteractablesLayer;
    public string InteractablesTag;
    public bool isExamining;
    private Transform currentExaminedObject;
    public GameObject ImageEndPosDisplay; //later on ill be lerping the game object to the player on their camera hence this
    private GameObject Pill;
    public string PillsTag;
    public TextMeshProUGUI PillsText;
    private GameObject Photo;
    public string PhotoTag;
    public TextMeshProUGUI PhotoText;
    private GameObject NewsPaper;
    public string NewsPaperTag;
    public TextMeshProUGUI NewsPaperText;
    private GameObject Skeleton;
    public string SkeletonTag;
    public TextMeshProUGUI SkeletonText;
    //storing original position
    private Dictionary<Transform, Vector3> originalPos = new Dictionary<Transform, Vector3>();

    [Header("Keys")]
    public LayerMask keyLayer;
    public string Key1Tag;
    public string Key2Tag;
    public string Key3Tag;

    [Header("Notes")]
    public LayerMask NoteBookLayer;
    public GameObject NoteBook1;
    public GameObject NoteBook2;
    public GameObject NoteBook1UI;
    public string NoteBook1Tag;
    public string NoteBook2Tag;
    public GameObject NoteBook2UI;
    private bool isNoteBook2Collected;

    [Header("DeadBodyStuff")]
    public GameObject DeadBody;
    public GameObject Skeleton2;

    SoundManager soundManager;
    LockedDoorManager DoorManager;
    AnimationManager animManager;
    GameScreenSwitcher gameScreenSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        Door = GameObject.FindGameObjectsWithTag(DoorTag);
        NoteBook1 = GameObject.FindGameObjectWithTag("NoteBook1");
        Pill = GameObject.FindGameObjectWithTag(PillsTag);
        Photo = GameObject.FindGameObjectWithTag(PhotoTag);
        NewsPaper = GameObject.FindGameObjectWithTag(NewsPaperTag);
        Skeleton = GameObject.FindGameObjectWithTag(SkeletonTag);

        NoteBook1UI.SetActive(false);
        DoorLockedText.enabled = false;
        PillsText.enabled = false;
        PhotoText.enabled = false;
        NewsPaperText.enabled = false;
        SkeletonText.enabled = false;
        Skeleton2.SetActive(false);

        foreach (var door in Door)
        {
            ToggleChildObject(door, false);
        }

        ToggleChildObject(Photo,false);
        ToggleChildObject(NoteBook1, false);
        ToggleChildObject(NoteBook2, false);
        ToggleChildObject(Pill, false);
        ToggleChildObject(NewsPaper, false);
        ToggleChildObject(Skeleton,false);

        animManager = GameObject.FindObjectOfType<AnimationManager>();
        DoorManager = GameObject.FindObjectOfType<LockedDoorManager>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        gameScreenSwitcher = GameObject.FindObjectOfType<GameScreenSwitcher>();

        isNoteBook2Collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorRaycast();
        ToggleExamine();

        if (DoorLockedText.enabled || NoteBook1UI.activeSelf || NoteBook2UI.activeSelf || isExamining)
        {

            Time.timeScale = 0f;
        }
        else if (DoorLockedText.enabled == false)
        {
            soundManager.PlaySound("DoorKnob");
            Time.timeScale = 1f;
        }

        if (isNoteBook2Collected)
        { 
            DeadBody.SetActive(false);
            Skeleton.SetActive(false);
            Skeleton2.SetActive(true);
        }
    }


    void DoorRaycast()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit Hit;

        //Door Raycast simple
        if (Physics.Raycast(ray, out Hit, rayDist, Doorlayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.green);
            ToggleChildObject(Hit.collider.gameObject,true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                soundManager.PlaySound("DoorOpen");
                animManager.OpenDoor(Hit.collider.gameObject.transform.parent.gameObject);
            }

        }
        else if (Physics.Raycast(ray, out Hit, rayDist, FinalDoorlayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.green);
            ToggleChildObject(Hit.collider.gameObject, true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                gameScreenSwitcher.SwitchScene();
            }

        }

        //Interactables RayCast slightly Tricky
        else if (Physics.Raycast(ray, out Hit, rayDist, InteractablesLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.white);
            ToggleChildObject(Hit.collider.gameObject, true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleExamination();
                if (isExamining)
                {  
                    soundManager.PlaySound("PickUp");
                    currentExaminedObject = Hit.transform;
                    originalPos[currentExaminedObject] = currentExaminedObject.position;

                }

                if (Hit.collider.tag == PillsTag)
                {
                    PillsText.enabled = !PillsText.enabled;
                }
                if (Hit.collider.tag == PhotoTag)
                {
                    PhotoText.enabled = !PhotoText.enabled;
                }
                if (Hit.collider.tag == NewsPaperTag)
                {
                    NewsPaperText.enabled = !NewsPaperText.enabled;
                }
                if (Hit.collider.tag == SkeletonTag)
                {
                    SkeletonText.enabled = !SkeletonText.enabled;
                }
            }

        }

        //LockedDoor RayCast slightly tricky I think
        else if (Physics.Raycast(ray, out Hit, rayDist, LockedDoorLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.blue);
            ToggleChildObject(Hit.collider.gameObject, true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorLockedText.enabled = !DoorLockedText.enabled;

            }
        }
        //Key RayCast 
        else if (Physics.Raycast(ray, out Hit, rayDist, keyLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.cyan);
            ToggleChildObject(Hit.collider.gameObject, true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Hit.collider.gameObject.tag == Key1Tag)
                {
                    Hit.collider.gameObject.SetActive(false);
                    DoorManager.isLockedDoor1 = true;
                }
                if (Hit.collider.gameObject.tag == Key2Tag)
                {
                    Hit.collider.gameObject.SetActive(false);
                    DoorManager.isLockedDoor2 = true;
                }
                if (Hit.collider.gameObject.tag == Key3Tag)
                {
                    Hit.collider.gameObject.SetActive(false);
                    DoorManager.isLockedDoor3 = true;
                }
            }
        }
        //NoteBook RayCast
        else if (Physics.Raycast(ray, out Hit, rayDist, NoteBookLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.cyan);
            ToggleChildObject(Hit.collider.gameObject, true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                soundManager.PlaySound("PageFlip");
                if (Hit.collider.gameObject.tag == NoteBook1Tag)
                {
                    NoteBook1UI.SetActive(!NoteBook1UI.activeSelf);
                }
                else if (Hit.collider.gameObject.tag == NoteBook2Tag)
                {
                    if (!isNoteBook2Collected)
                    {
                        soundManager.PlaySound("ThumpSound");
                    }
                    NoteBook2UI.SetActive(!NoteBook2UI.activeSelf);
                    isNoteBook2Collected = true;

                }
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.red);

            foreach (var door in Door)
            {
                ToggleChildObject(door, false);
            }

            ToggleChildObject(NoteBook1, false);
            ToggleChildObject(NoteBook2, false);
            ToggleChildObject(Pill, false);
            ToggleChildObject(Photo, false);
            ToggleChildObject(NewsPaper, false);
            ToggleChildObject(Skeleton, false);
        }
    }


    //Function to toggle child gameobject on and off
    void ToggleChildObject( GameObject parent , bool setActive)
    {
        foreach (Transform child in parent.transform)
        { 
            child.gameObject.SetActive(setActive);  
        }
    }


    void ToggleExamine()
    {
        if (isExamining)
        {
            Examine();
        }
        else
        { 
            NonExamine();
        }
    }


    void ToggleExamination()
    { 
        isExamining = !isExamining;
    }

    void Examine()
    {
        if (currentExaminedObject != null)
        {
            currentExaminedObject.position = Vector3.Lerp(currentExaminedObject.position, ImageEndPosDisplay.transform.position, 0.2f);
        }
    }

    void NonExamine()
    {
        if (currentExaminedObject != null)
        {
            if (originalPos.ContainsKey(currentExaminedObject))
            {
                currentExaminedObject.position = Vector3.Lerp(currentExaminedObject.position, originalPos[currentExaminedObject],0.2f);
            }
        }
    }
}
