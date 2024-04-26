using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DissapearingBody : MonoBehaviour
{
    public PlayerRayCastFlash playerRay;
    public GameObject BloodStains;
    public GameObject DeadBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRay = GetComponent<PlayerRayCastFlash>();
        BloodStains.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        JumpScare();
    }

    void JumpScare()
    {
        if (playerRay.isDissapearBody)
        { 
            DeadBody.SetActive(false);
            BloodStains.SetActive(true);

        }
    }


}
