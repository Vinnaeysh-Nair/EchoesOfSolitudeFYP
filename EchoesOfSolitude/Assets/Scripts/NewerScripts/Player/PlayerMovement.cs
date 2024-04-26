using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    private float CurrentSpeed;

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrentSpeed = RunSpeed;
        }
        else
        {
            CurrentSpeed = WalkSpeed;
            

        }

        controller.Move(move * CurrentSpeed * Time.deltaTime);
        
    }
}
