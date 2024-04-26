using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobTriggerScript : MonoBehaviour
{
    public bool isRunningMob;
    public GameObject Mobster;
    public GameObject Door;
    public string RunAnimName;
    public string DoorCloseAnimName;
    public float Speed;
    public float DoorOpenTimer;
    public AudioSource laughing;

    // Start is called before the first frame update
    void Start()
    {
        Mobster.SetActive(false);
        isRunningMob = false;
        laughing.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunningMob)
        {
            MonsterRun();
            StartCoroutine(CloseDoorTimer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Mobster.SetActive(true);
        isRunningMob=true;
        
    }

    void MonsterRun()
    {
        Mobster.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        Mobster.GetComponent<Animator>().Play(RunAnimName);
        laughing.enabled=true;
    }

    IEnumerator CloseDoorTimer()
    {
        yield return new WaitForSeconds(DoorOpenTimer);
        Door.GetComponent<Animator>().Play(DoorCloseAnimName);
    }
}
