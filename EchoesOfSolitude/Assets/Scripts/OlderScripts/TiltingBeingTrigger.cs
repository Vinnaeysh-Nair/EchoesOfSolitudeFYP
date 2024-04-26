using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingBeingTrigger : MonoBehaviour
{
    [Header("Being1")]
    public GameObject Being1;
    Animator anim;
    public string AnimName;
    public bool currentlyTilting;
    public void Start()
    {
        anim = Being1.GetComponent<Animator>();
        currentlyTilting = false;
    }
    public void Update()
    {
        if (currentlyTilting)
        {
            TiltAnimation();
            StartCoroutine(DisableSelf());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        currentlyTilting = true;
    }

    void TiltAnimation()
    {
        anim.SetBool(AnimName,true);
    }
    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Collider>().enabled = false;
        Being1.SetActive(false);
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
