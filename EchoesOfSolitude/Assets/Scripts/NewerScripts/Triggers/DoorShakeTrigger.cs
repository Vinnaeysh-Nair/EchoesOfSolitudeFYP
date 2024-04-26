using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShakeTrigger : MonoBehaviour
{
    public GameObject ShakingDoor;
    AnimationManager animManager;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        animManager = GameObject.FindObjectOfType<AnimationManager>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animManager.ShakeDoor(ShakingDoor);
        this.gameObject.SetActive(false);
        soundManager.PlaySound("BangingDoor");
        Debug.Log("I have collided with the box");
        
    }
}
