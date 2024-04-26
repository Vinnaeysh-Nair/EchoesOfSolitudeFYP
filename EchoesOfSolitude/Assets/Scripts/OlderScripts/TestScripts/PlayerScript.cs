using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private float Speed;
    float GDrag =  9f;
    public Transform orientation;
    private float Horizontal;
    private float Vertical;
    
    private Vector3 movement;

    Rigidbody rb;

    [Header("PLayer tilting")]
    public float TiltAngle = 45f;
    public float TiltSpeed = 5f;
    public bool isTilting = false;
    private Quaternion ogRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ogRotation = transform.rotation;
        rb.drag = GDrag;
    }

    // Update is called once per frame
    void Update()
    {
        PInput();
        DetectRun();
        
    }

    void FixedUpdate()
    {
        PMove();
    }

    void PInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
    }

    void PMove()
    { 
        movement = orientation.forward * Vertical + orientation.right * Horizontal;

        rb.AddForce(movement * Speed * 1f, ForceMode.Force); 
    }


    //Working On this still
    void CamPeak()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Player Currently Peeking");

            float tiltInput = Input.GetAxis("Mouse X");
            Quaternion targetRotation = Quaternion.Euler(0, 0, -tiltInput * TiltAngle);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, TiltSpeed * Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Player Currently Not  Peeking");
            transform.localRotation = Quaternion.Slerp(transform.localRotation, ogRotation, TiltSpeed * Time.deltaTime * 10f);
        }
    }

    void DetectRun()
    {
        if ( Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("is Currently running");
            GDrag = 6;

            rb.drag = GDrag;    
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("is currently walking");
            GDrag = 9;

            rb.drag = GDrag;
        }
    }
}
