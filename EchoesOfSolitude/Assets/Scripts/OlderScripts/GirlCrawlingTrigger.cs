using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GirlCrawlingTrigger : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject girl;

    [Header("Variables")]
    public bool isTilting;
    public float MoveSpeed;

    [Header("Animation")]
    public string CrawlAnimName;

    [Header("Coroutines")]
    public float DisableGirlTimer;

    [Header("Static Script Reference")]
    public string StaticGameObjectName;
    public GameObject UIStatic;
    private StaticScript staticScriptReference;
    public float AlphaAddOn;
    public float statictimer;

    [Header("Sound")]
    public AudioSource GirlWhisperSound;
    public float fadeDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        isTilting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTilting)
        {
            GirlRunning();
            StartCoroutine(DisableGirl());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        isTilting = true;
    }

    void GirlRunning()
    {
        girl.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
    }

    IEnumerator DisableGirl()
    { 
        yield return new WaitForSeconds(DisableGirlTimer);
        girl.SetActive(false);
    }
}
