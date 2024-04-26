using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningTrigger : MonoBehaviour
{
    public GameObject RunningMob;
    [SerializeField] private int Speed;
    [SerializeField] private bool isMoving = false;
    public MonoBehaviour MobRunningScript;
    private BoxCollider bx;
    SoundManager SoundManage;

    // Start is called before the first frame update
    void Start()
    {
        RunningMob.SetActive(false);
        SoundManage = GameObject.FindObjectOfType<SoundManager>();
        bx = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            RunningMob.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            StartCoroutine(DisableMob());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        RunningMob.SetActive(true);
        SoundManage.PlaySound("RunningSound");
        isMoving = true;
        bx.enabled = false;
    }

    IEnumerator DisableMob()
    { 
        yield return new WaitForSeconds(3);
        RunningMob.SetActive(false);
        MobRunningScript.enabled = false;

    }
}
