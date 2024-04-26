using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveSet
{
    public List<string> objective_ids = new List<string>();
    public List<bool> objective_met = new List<bool>();
}

public class ObjectivesManager : MonoBehaviour
{
    static ObjectivesManager instance;

    public static void CompleteObjective(string id)
    {
        switch(id)
        {
            case "FLASH_COLLECT":
                {
                    instance.CrossObj1.SetActive(true);
                    instance.CompleteObj(0);
                }
                break;
            case "READ_NOTE_1":
                {
                    instance.CrossObj2.SetActive(true);
                    instance.CompleteObj(1);
                }
                break;
        }

    }

    [Header("UI title")]
    public GameObject GameObjectiveUIHeader;
    public Animator GameUIFadeIn;
    //private bool isLoaded;

    [Header("Static")]
    public GameObject Static;
    StaticScript statScript;

    [Header("Objectives")]
    public GameObject Objective1;
    public GameObject Objective2;
    //bool isAchieved;
    //bool isAchieved1;
    //bool isAchieved2;
    [Header("Crosses")]
    public GameObject CrossObj1;
    public GameObject CrossObj2;

    [Header("Doors")]
    public GameObject Door1;
    public Animation Door1Anim;

    public GameObject NoteBook1;
    public GameObject PlayerTorch;
    NoteBook1 Nb1;
    FlashlightScript flashlight;

    List<ObjectiveSet> sets;
    int currentSetIndex = 0;

    ObjectiveSet CurrentSet { get => sets[currentSetIndex]; }

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Ensure only 1 instance
        instance = this;

        statScript = Static.GetComponent<StaticScript>();
        Nb1 = NoteBook1.GetComponent<NoteBook1>();
        flashlight = PlayerTorch.GetComponent<FlashlightScript>();
        Door1Anim = Door1.GetComponent<Animation>();
        Objective1.SetActive(false);
        Objective2.SetActive(false);
        CrossObj1.SetActive(false);
        CrossObj2.SetActive(false); 
        //isLoaded = false;
        //isAchieved = false;
        statScript.onLoadTitle.AddListener(LoadObjectiveUI2);

        sets = new List<ObjectiveSet>();

        ObjectiveSet first = new();
        first.objective_ids.Add("FLASH_COLLECT");
        first.objective_met.Add(false);
        first.objective_ids.Add("READ_NOTE_1");
        first.objective_met.Add(false);
        sets.Add(first);
        currentSetIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //LoadObjectiveUI();
        //LoadObjectives1();
        //DetectObjectives();
        //DetectRemoveObjectives();
    }

    //Checks if the Static dissapears
    //void LoadObjectiveUI()
    //{
    //    if (statScript.LoadTitle)
    //    {
    //        StartCoroutine(LoadingObjective());
    //    }
    //}

    //Checks if the Static dissapears
    void LoadObjectiveUI2()
    {
        statScript.onLoadTitle.RemoveListener(LoadObjectiveUI2);
        GameUIFadeIn.SetBool("isObjective", true);
        //isLoaded = true;
        StartCoroutine(LoadingFirstObjectives());
        //StartCoroutine(LoadingObjective());
    }

    //Loads the Title
    //IEnumerator LoadingObjective()
    //{
    //    yield return new WaitForSeconds(2f);
    //    GameUIFadeIn.SetBool("isObjective", true);
    //    isLoaded = true;
    //}


    //public void LoadObjectives1()
    //{ 
    //    if (isLoaded)
    //    {
    //        StartCoroutine(LoadingFirstObjectives());
    //    }
    //}

    IEnumerator LoadingFirstObjectives()
    {
        yield return new WaitForSeconds(1.5f);
        Objective1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Objective2.SetActive(true);
    }

    //public void DetectObjectives()
    //{
    //    if (flashlight.isFlashCollected)
    //    {
    //        CrossObj1.SetActive(true);
    //    }
    //    if (Nb1.ObjectiveCompleted)
    //    {
    //        CrossObj2.SetActive(true);
    //    }
    //}

    public void DetectRemoveObjectives()
    {
        if (flashlight.isFlashCollected && Nb1.ObjectiveCompleted)
        {
            Objective1.SetActive(false);
            Objective2.SetActive(false);
            Door1Anim.Play("Door1_Open");
        }
    }

    private void CompleteObj(int i)
    {
        CurrentSet.objective_met[i] = true;

        ResolveObjectiveGroup();
    }

    private void ResolveObjectiveGroup()
    {
        foreach(bool b in CurrentSet.objective_met)
        {
            if(!b)
            {
                // Some objectives not completed, so return early.
                return;
            }
        }

        Debug.Log("Objective set completed!");
        Debug.Log("Do stuff when objective set is complete!");

        if(currentSetIndex == 0)
        {
            Objective1.SetActive(false);
            Objective2.SetActive(false);
            Door1Anim.Play("Door1_Open");
        }

        currentSetIndex++;

        if(currentSetIndex < sets.Count)
        {
            // disappear current set
            // populate with next set
            // appear new objective set
        }
        else
        {
            // ALL OBJECTIVES COMPLETED
        }
    }



}
