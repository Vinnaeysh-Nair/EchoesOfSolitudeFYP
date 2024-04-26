using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeTrigger : MonoBehaviour
{
    public GameObject SmokeParticle;
    private ParticleSystem _particleSystem;
    [SerializeField] private float StopSmoke;
    [SerializeField] private float SmokeDuration;
    private bool isFading;
    private float fadeSmoke;
    SoundManager SoundManage;
    private BoxCollider Boxcollider;
    
    // Start is called before the first frame update
    void Start()
    {
        SmokeParticle.SetActive(false);
        _particleSystem = SmokeParticle.GetComponent<ParticleSystem>();
        SoundManage = GameObject.FindObjectOfType<SoundManager>();
        Boxcollider = this.GetComponent<BoxCollider>();
        fadeSmoke = SmokeDuration;
        isFading = false;
    }

    private void Update()
    {
        if (isFading)
        {
            FadingSmokeFunc();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        SmokeParticle.SetActive(true);
        StartCoroutine(FadeSmoke());
        Boxcollider.enabled = false ;
        SoundManage.PlaySound("AirPressureSound");
    }


    IEnumerator FadeSmoke()
    {
        yield return new WaitForSeconds(StopSmoke);
        isFading = true;

    }

    void FadingSmokeFunc()
    {
        fadeSmoke -= Time.deltaTime;
        Debug.Log("Timer " + fadeSmoke);
        if (fadeSmoke <= 0f)
        {
            SmokeParticle.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            float SmokeAlpha = fadeSmoke / SmokeDuration;

            var ParticleModule = _particleSystem.main;

            Color StartColor = ParticleModule.startColor.color;

            StartColor.a = SmokeAlpha;

            ParticleModule.startColor = StartColor;

        }
    }

}
