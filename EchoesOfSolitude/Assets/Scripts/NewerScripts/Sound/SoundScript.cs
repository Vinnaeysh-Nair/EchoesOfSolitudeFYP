using UnityEngine.Audio;
using UnityEngine;
using System.Globalization;

[System.Serializable]
public class SoundScript
{
    public string Name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
    public bool loop;
    public bool mute;
    [HideInInspector]
    public AudioSource source;
}
