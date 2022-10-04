using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    [SerializeField] private Camera cam;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    


    private void FixedUpdate()
    {
        //Performs calculations on rigidbody in FixedUpdate
        PerformMovement();
        PerformRotation();
        
    }

    //Perform camera rotation in update 
    private void Update()
    { 
        PerformCameraRotation();
    }


    //Gets rotational Vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Apply rotational Vector on rigidbody
    private void PerformRotation()
    {
        if(rotation != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        }

    }


    //Gets movement Vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Apply movement Vector on rigidbody
    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    //Apply rotational Vector on camera
    private void PerformCameraRotation()
    {
        if (cameraRotation != Vector3.zero && cam != null)
        {
            cam.transform.Rotate(cameraRotation);
        }

    }


}
