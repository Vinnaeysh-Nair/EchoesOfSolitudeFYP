using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Sensitivity")]
    public float sensX;
    public float sensY;

    [Header("Orientation")]
    public Transform orientation;

    [Header("Y rotation clamp")]
    public float yClamp;

     float rotationX;
     float rotationY;



    

    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
    }

    void LockCursor()
    { 
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }

    void MouseInput()
    { 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotationY += mouseX;

        rotationX -= mouseY;

        //Clamping rotation for rotationX
        rotationX = Mathf.Clamp(rotationX, -yClamp, yClamp);


        //Rotate Camera and Orientation
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY,0);
    }

    

}
