using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingBody : MonoBehaviour
{
    public GameObject DeadBody;

    // Start is called before the first frame update
    void Start()
    {
        DeadBody.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        DeadBody.SetActive(true);
    }
}
