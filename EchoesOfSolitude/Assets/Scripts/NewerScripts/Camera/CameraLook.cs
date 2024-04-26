using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float MouseX;
    private float MouseY;
    private float xRot = 0f;
    [SerializeField] private float  MouseSens = 100f;
    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Input for movement on X and Y axis
        MouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

        xRot -= MouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        //Rotating Player Body
        playerBody.Rotate(Vector3.up * MouseX);



    }
}
