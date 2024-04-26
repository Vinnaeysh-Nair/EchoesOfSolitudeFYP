using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorManager : MonoBehaviour
{
    public bool isLockedDoor1;
    public bool isLockedDoor2;
    public bool isLockedDoor3;
    public GameObject lockedDoor1;
    public GameObject lockedDoor2;
    public GameObject lockedDoor3;
    public int UnlockedDoorLayerIndex;
    public int FinalDoorLayerIndex;


    // Start is called before the first frame update
    void Start()
    {
        isLockedDoor1 = false;
        isLockedDoor2 = false;
        isLockedDoor3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLockedDoor1 && lockedDoor1 != null)
        {
            // Verify that UnlockedDoorLayer is within the valid range [0..31]
            if (UnlockedDoorLayerIndex >= 0 && UnlockedDoorLayerIndex <= 31)
            {
                // Assign the layer using the layer index
                lockedDoor1.layer = UnlockedDoorLayerIndex;
                Debug.Log("First door has been unlocked");
            }
            else
            {
                Debug.LogError("UnlockedDoorLayer is not a valid layer index.");
            }
        }

        if (isLockedDoor2 && lockedDoor2 != null)
        {
            // Verify that UnlockedDoorLayer is within the valid range [0..31]
            if (UnlockedDoorLayerIndex >= 0 && UnlockedDoorLayerIndex <= 31)
            {
                // Assign the layer using the layer index
                lockedDoor2.layer = UnlockedDoorLayerIndex;
                Debug.Log("Second door has been unlocked");
            }
            else
            {
                Debug.LogError("UnlockedDoorLayer is not a valid layer index.");
            }
        }

        if (isLockedDoor3 && lockedDoor3 != null)
        {
            // Verify that UnlockedDoorLayer is within the valid range [0..31]
            if (UnlockedDoorLayerIndex >= 0 && UnlockedDoorLayerIndex <= 31)
            {
                // Assign the layer using the layer index
                lockedDoor3.layer = FinalDoorLayerIndex;
                Debug.Log("Third door has been unlocked");
            }
            else
            {
                Debug.LogError("UnlockedDoorLayer is not a valid layer index.");
            }
        }
    }
}
