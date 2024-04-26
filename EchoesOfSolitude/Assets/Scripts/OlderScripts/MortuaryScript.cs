using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortuaryScript : MonoBehaviour
{
    public KeyInteract keyInteract;
    public GameObject MortKey;
    public GameObject MortBodyLayer1;
    public GameObject MortBodyLayer2;
    public GameObject BloodStains;
    public GameObject CorridorTrigger;
    public AudioSource MortuarySounds;
    // Start is called before the first frame update
    void Start()
    {
        keyInteract = MortKey.GetComponent<KeyInteract>();
        MortBodyLayer1.SetActive(true);
        MortBodyLayer2.SetActive(false);
        BloodStains.SetActive(false);
        CorridorTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MortuaryTrigger();
    }


    void MortuaryTrigger()
    {
        if (keyInteract.ActivateJumpScare)
        {
            MortBodyLayer1.SetActive(false);
            MortBodyLayer2.SetActive(true);
            BloodStains.SetActive(true);
            CorridorTrigger.SetActive(true);
            MortuarySounds.Play();
        }
    }
}
