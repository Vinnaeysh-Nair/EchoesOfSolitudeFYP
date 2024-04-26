using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTE2TRIGGER : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider boxCollide;
    public GameObject Girl;
    public GameObject GirlBoxTrigger;
    void Start()
    {
        boxCollide = GetComponent<BoxCollider>();
        Girl.SetActive(false);
        GirlBoxTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GirlBoxTrigger.SetActive(true);
        Girl.SetActive(true);
    }

}
