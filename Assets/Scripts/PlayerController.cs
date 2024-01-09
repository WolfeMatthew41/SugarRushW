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
    private float speed = 2f; //Used to control speed of Puff

    [SerializeField]
    private float smoothTime = 0.08f;

    [SerializeField]
    private float _currentVelocity;

    private float _gravity = -9.81f; //Used to control fall speed

    [SerializeField] 
    private float gravityMultiplyer = 3.0f;
    private float _velocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        Debug.Log(_input);// message: "PlayerController Moving!");
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    private void Update()
    {
        //ApplyRotation();
        ApplyMovement();
        ApplyGravity();
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return; // dont rotate unless player input
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed);
    }

    private void ApplyGravity()
    {
        _velocity += _gravity * gravityMultiplyer * Time.deltaTime;
        _direction.y = _velocity;
    }
}
