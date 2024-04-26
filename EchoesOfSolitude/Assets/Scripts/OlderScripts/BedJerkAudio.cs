using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedJerkAudio : MonoBehaviour
{
    public AudioSource BedJumpScareSound;
    public void BedJumpScareAudio()
    {
        BedJumpScareSound.Play();
    }
}
