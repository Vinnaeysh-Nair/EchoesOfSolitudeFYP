using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelManagerScript : MonoBehaviour
{
    [Header("Door1Stuff")]
    public GameObject Door;
    public Animation DoorAnim;
    public AudioSource doorCreaking;
    public GameObject PlayerFlash;
    public GameObject NoteBook1;
    FlashlightScript flashScript;
    NoteBook1 nB1;
    private bool isDoorOpening = false;


    [Header("Mortuary JumpScare")]
    public GameObject Keys3;
    public GameObject Notebook3;
    public GameObject MortuaryTrigger;
    public bool isCollected;



    // Start is called before the first frame update
    void Start()
    {
        DoorAnim = Door.GetComponent<Animation>();
        flashScript = PlayerFlash.GetComponent<FlashlightScript>(); 
        nB1 = NoteBook1.GetComponent<NoteBook1>();
        MortuaryTrigger.SetActive(false);
        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoorEvent();
        EnableTrigger();
    }

    void OpenDoorEvent()
    {
        if (!isDoorOpening && flashScript.isFlashCollected && nB1.isReadAudio)
        {
            isDoorOpening = true;
            StartCoroutine(DoorFunc());
        }
    }

    IEnumerator DoorFunc()
    {
        yield return new WaitUntil(() => isDoorOpening);

        DoorAnim.Play("Door1_Open");
        Debug.Log("DoorCurrently Opening");
        doorCreaking.Play();
    }

    public void EnableTrigger()
    {
        if (!Keys3.activeSelf && !Notebook3.activeSelf)
        {
            MortuaryTrigger.SetActive(true);
        }
    }


}
