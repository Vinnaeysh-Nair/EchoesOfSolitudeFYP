using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public SoundScript[] Sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (SoundScript s in Sounds)
        { 
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    private void Start()
    {
        PlaySound("BgSound");
    }

    public void PlaySound(string name)
    {
        SoundScript s = Array.Find(Sounds,SoundScript => SoundScript.Name == name);
        s.source.Play();
    }

    public void StopSound(string name)
    {
        SoundScript s = Array.Find(Sounds, SoundScript => SoundScript.Name == name);
        s.source.Stop();
    }
}
