using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private float speed;

    private float lookSensitivity;

    


    private PlayerMotor motor;

    private void Start()
    {
        speed = 5f;
        lookSensitivity = 5f;
        motor = GetComponent<PlayerMotor>();
    }
    private void Update()
    {
        float _xMove =  Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        //Calculate movement velocity as a Vector3
        Vector3 _movHoriz = transform.right * _xMove;
        Vector3 _movVert = transform.forward * _zMove;
        //Final velocity for movement
        Vector3 _velocity = (_movHoriz + _movVert).normalized * speed;

        //Applying velocity to motor component
        motor.Move(_velocity);

        //Calculate rotation as a 3D Vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");        
        Vector3 _rotation = new Vector3(0f ,_yRot , 0f);
        //Applying sensitivity
        _rotation *= lookSensitivity;

        //Applying rotation to Player
        motor.Rotate(_rotation);

        //Mapping looking up and down to the camera
        float _xRot = Input.GetAxisRaw("Mouse Y");

        //We add a minus sign to xRot to invert axis
        Vector3 _cameraRotation = new Vector3(-_xRot, 0f, 0f);

        //Rotate the camera with look sensitivity
        motor.RotateCamera(_cameraRotation * lookSensitivity);


        




    }

    
}
