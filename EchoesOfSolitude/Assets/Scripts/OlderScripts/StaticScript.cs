using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;

public class StaticScript : MonoBehaviour
{
    RawImage rImage;
    public float Timer = 2f;
    public float fadeDuration = 2f;
    public float targetAlpha = 0.2f;
    public  float initialAlpha;
    public float currentAlpha;
    public bool fading = false;
    public VideoClip StaticClip;
    public VideoClip NormalStatic;
    public VideoPlayer videoplayer;
    public AudioSource StaticAudioSource;
    public float TargetAudioVolume;
    public bool LoadTitle;

    public UnityEvent onLoadTitle = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        rImage = GetComponent<RawImage>();
        videoplayer = GetComponent<VideoPlayer>();
        StaticAudioSource = GetComponent<AudioSource>();
        initialAlpha = rImage.color.a;
        currentAlpha = initialAlpha;
        LoadTitle = false;
        StartCoroutine(SlowDownStatic());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (!fading)
    //    {
    //        StartCoroutine(SlowDownStatic());
    //    }
    //}

    IEnumerator SlowDownStatic()
    {
        fading = true;
        yield return new WaitForSeconds(Timer);

        float timer = 0f;
        float startVolume = StaticAudioSource.volume;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            currentAlpha = Mathf.Lerp(initialAlpha, targetAlpha, timer / fadeDuration);
            rImage.color = new Color(rImage.color.r, rImage.color.g, rImage.color.b, currentAlpha);
            StaticAudioSource.volume = Mathf.Lerp(startVolume, TargetAudioVolume, timer/fadeDuration);
            
            yield return null;
        }

        LoadTitle = true;
        onLoadTitle.Invoke();
    }

    public void SuddenStatic()
    {
        currentAlpha = 1;
        StaticAudioSource.volume = 0.2f;
        StaticAudioSource.Play();
        rImage.color = new Color(rImage.color.r, rImage.color.g, rImage.color.b, currentAlpha);
        StartCoroutine(ResetStatic());
    }

    IEnumerator ResetStatic()
    {
        yield return new WaitForSeconds(3f);
        currentAlpha = 0.007f;
        rImage.color = new Color(rImage.color.r, rImage.color.g, rImage.color.b, currentAlpha);
        StaticAudioSource.volume = 0;
        StaticAudioSource.Stop();

    }

}
