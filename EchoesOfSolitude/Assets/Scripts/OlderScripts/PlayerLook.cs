using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform Player;
    public Transform Camera;

    public float xSens;
    public float ySens;
    public float xClamp;

    private Quaternion camCenter;

    PlayerMovement pMove;

    // Start is called before the first frame update
    void Start()
    {
        camCenter = Camera.localRotation; //Rotation origin of the camera
        pMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        SetVertical();
        SetHorizontal();
    }

    void SetVertical()
    {
        float t_Input = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;

        //Rotates a certain amount of angle from a certain axis
        Quaternion t_adj = Quaternion.AngleAxis(t_Input, -Vector3.right);
        Quaternion t_delta = Camera.localRotation * t_adj;
        Camera.localRotation = t_delta;

        if (Quaternion.Angle(camCenter, t_delta) < xClamp)
        { 
            Camera.localRotation = t_delta;
        }
    }

    void SetHorizontal()
    {
        float t_Input = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;

        //Rotates a certain amount of angle from a certain axis
        Quaternion t_adj = Quaternion.AngleAxis(t_Input, Vector3.up);
        Quaternion t_delta = Player.localRotation * t_adj;
        Player.localRotation = t_delta;
    }
}
