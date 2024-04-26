using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlashDoorOpenScript : MonoBehaviour
{
    public GameObject Keys;
    public PlayerRayCastFlash pRayFlash;
    public bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        pRayFlash = GetComponent<PlayerRayCastFlash>();
        Keys.SetActive(false);
        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActiveKeys();
    }

    void ActiveKeys()
    {
        if (pRayFlash.isKeyDropped && !isCollected)
        {
            Keys.SetActive(true);
            isCollected=true;
        }
    }
}
