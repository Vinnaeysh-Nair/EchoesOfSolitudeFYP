using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDoorScript : MonoBehaviour
{
    [SerializeField] Text interact;
    public LayerMask doorLayer;
    [SerializeField] float RayCastDist;
    public bool isDoor;
    public bool DoorOpenBool;
    public string isOpen;
    public GameObject Door;
    public GameObject DoorPart;

    // Start is called before the first frame update
    void Start()
    {
        interact.enabled = false;
        DoorOpenBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        DrawRaycast();
        DoorOpenUI();
    }

    void DrawRaycast()
    {
        //Starting pos and direction for raycast
        Ray DoorRay = new Ray(transform.position, transform.forward);

        RaycastHit DoorHit;

        if (Physics.Raycast(DoorRay, out DoorHit, RayCastDist, doorLayer))
        {
            if (DoorHit.collider != null)
            {
                GameObject hitObject = DoorHit.collider.gameObject;

                Vector3 hitPoint = DoorHit.point;

                Debug.Log("Raycast hit " + hitObject);

                //Draw Ray
                Debug.DrawRay(DoorRay.origin, DoorRay.direction * RayCastDist, Color.red);

                isDoor = true;
            }
        }
        else
        { 
            isDoor = false;
        }
    }

    void DoorOpenUI()
    {
        if (isDoor)
        {
            interact.enabled = true;
            DoorOpen();
        }
        else if (!isDoor)
        {
            interact.enabled = false;
        }
    }

    void DoorOpen()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Door is being Opened");
            Door.GetComponent<Animation>().Play("Door1_Open");
            DoorPart.GetComponent<MeshCollider>().enabled = false;
            DoorOpenBool = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && DoorOpenBool)
        {
            Debug.Log("Door is being closed");
            Door.GetComponent<Animation>().Play("Door1_Close");
            DoorPart.GetComponent<MeshCollider>().enabled = true;
            DoorOpenBool = false;
        }
    }

}
