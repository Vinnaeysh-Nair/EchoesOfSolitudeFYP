using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortuaryDoorTrigger : MonoBehaviour
{
    public GameObject MortDoor;
    public string DoorAnimName;
    public Animation DoorOpen;
    public AudioSource DoorOpenSound;
    // Start is called before the first frame update
    void Start()
    {
        DoorOpen = MortDoor.GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        DoorOpen.Play(DoorAnimName);
        this.gameObject.GetComponent<Collider>().enabled = false;
        DoorOpenSound.Play();
        StartCoroutine(DisableThis());
    }


    IEnumerator DisableThis()
    {
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);
    }
}
