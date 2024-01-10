using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _direction;
    private CharacterController _characterController;
    [SerializeField]
    private float speed = 0.053f; //Used to control speed of Puff

    [SerializeField]
    private float smoothTime = 0.3f;

    [SerializeField]
    private float _currentVelocity;

    [SerializeField]
    private float _gravity = -9.81f; //Used to control fall speed

    [SerializeField] 
    private float gravityMultiplyer = .2f;
    private float _velocity;


    private float rotationX;
    private float rotationY;

    private float currentAngle;

    private Vector3 movementDirection;

    private Vector3 currentDirection;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        //Debug.Log(_input);// message: "PlayerController Moving!");
        if (currentAngle > 135.0f && currentAngle < 225.0f) //Facing Backards VVV
            _direction = new Vector3(_input.x * -1, 0.0f, _input.y * -1);
        else if (currentAngle > 45.0f && currentAngle < 135.0f) //Facing Right -->
        {
            _direction = new Vector3(_input.y, 0.0f, _input.x *-1 );
        }
        else if (currentAngle > 225.0f && currentAngle < 270.0f) //Facing Left <---
        {
            _direction = new Vector3(_input.y*-1, 0.0f, _input.x);
        }
        else
            _direction = new Vector3(_input.x, 0.0f, _input.y); //Facing forward ^^^
      
        movementDirection = _direction;
    }

    private void Update()
    {
        ApplyRotation();
       
        ApplyGravity();

        ApplyMovement();
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
       
        currentAngle = angle;
        Debug.Log(currentAngle);
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity < 0.0f)
            _velocity = -1.0f;
        else
            _velocity += _gravity * gravityMultiplyer * Time.deltaTime;
        _direction.y = _velocity;
    }

    private void ApplyMovement()
    {

        _characterController.Move(_direction * speed);
    }
}
