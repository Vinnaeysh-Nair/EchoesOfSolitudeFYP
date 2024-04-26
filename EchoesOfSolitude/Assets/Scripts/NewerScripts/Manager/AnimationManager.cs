using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public void OpenDoor(GameObject Door)
    {
        Animator door = Door.GetComponent<Animator>();

        door.SetBool("isOpen", true);
    }

    public void ShakeDoor(GameObject Door)
    { 
        Animator door = Door.GetComponent <Animator>();
        door.SetBool("isSlam", true);
    }

    public void TorchLightOn(GameObject torchLight)
    {
        Animator door = torchLight.GetComponent<Animator>();
        door.SetBool("isCarry", true);
    }

    public void TorchLightOff(GameObject torchLight)
    {
        Animator door = torchLight.GetComponent<Animator>();
        door.SetBool("isCarry", false);
    }

    public void GirlCrawl(GameObject GirlCrawl)
    {
        Animator girlCrawling = GirlCrawl.GetComponent<Animator>();
        girlCrawling.SetBool("GirlTriggered", true);
    }

    public void ChairFalling(GameObject ChairFalling)
    {
        Animator chairFalling = ChairFalling.GetComponent<Animator>();
        chairFalling.SetBool("isChairFalling", true);
    }

    public void VentilatorClose(GameObject Vent)
    {
        Animator ventClose = Vent.GetComponent<Animator>();
        ventClose.SetBool("ventClose", true);
    }
}
