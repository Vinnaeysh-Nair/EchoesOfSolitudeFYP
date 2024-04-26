using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TutorialManager : MonoBehaviour
{
    public GameObject TutoriaPanel;
    public TextMeshProUGUI TutorialText;
    public string[] tutorialMessages;
    private int currentStep = 0;
    public GameObject DoorA;
    public TextMeshPro DoorInteractE;
    public GameObject DoorB;
    AnimationManager animManage;
    SoundManager SoundManage;
    private bool isMove;
    private bool isRun;
    private bool isFlash;
    private bool isInteract;
    // Start is called before the first frame update
    void Start()
    {
        ShowTutorialStep();
        DoorInteractE.enabled = false;
        animManage = GameObject.FindObjectOfType<AnimationManager>();
        SoundManage = GameObject.FindObjectOfType<SoundManager>();
        isMove = false;
        isRun = false;  
        isFlash = false;
        isInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMove)
        {
            NextStep();
            isMove = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) & !isRun)
        {
            NextStep();
            isRun = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && !isFlash)
        {
            NextStep();
            isFlash = true;
            DoorInteractE.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && !isInteract)
        {
            isInteract = true;
            DoorInteractE.enabled = false;
            animManage.OpenDoor(DoorA);
            animManage.OpenDoor(DoorB);
            SoundManage.PlaySound("ElevatorDing");
            SoundManage.PlaySound("Breathing");
            NextStep();
        }
    }

    void ShowTutorialStep()
    {
        if (currentStep < tutorialMessages.Length)
        {
            TutoriaPanel.SetActive(true);
            TutorialText.text = tutorialMessages[currentStep];
        }
        else
        {
            TutoriaPanel.SetActive(false); 
        }
    }

    public void NextStep()
    { 
        currentStep++;
        ShowTutorialStep();
    }
}
