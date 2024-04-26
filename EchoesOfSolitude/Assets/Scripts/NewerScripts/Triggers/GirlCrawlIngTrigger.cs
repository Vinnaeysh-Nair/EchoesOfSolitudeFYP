using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCrawlIngTrigger : MonoBehaviour
{
    public GameObject CrawlingGirl;
    public GameObject Chair;
    public GameObject Vent;
    AnimationManager animationManager;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        animationManager = GameObject.FindObjectOfType<AnimationManager>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        animationManager.GirlCrawl(CrawlingGirl);
        animationManager.ChairFalling(Chair);
        soundManager.PlaySound("ChairFallSound");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(ClosingVent());

    }

    IEnumerator ClosingVent()
    {
        yield return new WaitForSeconds(1.3f);
        soundManager.PlaySound("VentDoorClose");
        animationManager.VentilatorClose(Vent);
        this.gameObject.SetActive(false);
    }
}
