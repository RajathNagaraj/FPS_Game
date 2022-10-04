using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private PlayerMotor motor;

    private void Start()
    {
        speed = 5f;
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
        //Applying velocity to motor
        motor.Move(_velocity);

        
    }
}
