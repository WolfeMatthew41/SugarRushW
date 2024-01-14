using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _direction;
    private Vector3 _direction2;
    private Vector3 _direction3;
    private CharacterController _characterController;
    [SerializeField]
    private float speed = 0.25f; //Used to control speed of Puff

    [SerializeField]
    private float smoothTime = 0.28f;

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

    private int movementDirection;


    private bool isRotating = false;
    private bool hasEventBeenTriggered = false;
    public AK.Wwise.Event Play_Footstep;

    private bool isPaused = false;

    private GameObject[] puffPlayer;
    private bool hasMoved = false;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        puffPlayer = GameObject.FindGameObjectsWithTag("PuffModel");
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!isPaused) 
        {
            _input = context.ReadValue<Vector2>();
            //Debug.Log(_input);// message: "PlayerController Moving!");
            /*
            if (currentAngle > 135.0f && currentAngle < 225.0f) //Facing Backards VVV
            {
                _direction = new Vector3(_input.x * -1, 0.0f, _input.y * -1);
                movementDirection = 2;
            }
            else if (currentAngle > 45.0f && currentAngle < 135.0f) //Facing Right -->
            {
                _direction = new Vector3(_input.y, 0.0f, _input.x * -1);
                movementDirection = 1;
            }
            else if (currentAngle > 225.0f && currentAngle < 315.0f) //Facing Left <---
            {
                _direction = new Vector3(_input.y * -1, 0.0f, _input.x);
                movementDirection = 3;
            }
            else
            {
                _direction = new Vector3(_input.x, 0.0f, _input.y); //Facing forward ^^^
                movementDirection = 0;
            }*/
            //*** Moves Player based On Camera *** //
            //Get PLayer Input
            float playerVerticalInput = Input.GetAxis("Vertical");
            float playerHorizontalInput = Input.GetAxis("Horizontal");

            //Get Camera Normalized Directional Vector
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            //----
            //Get Camera Normalized Directional Vectors
            forward.y = 0;
            right.y = 0;
            forward = forward.normalized;
            right = right.normalized;

            //----
            //Create direction-relative-input vectors
            Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
            Vector3 rightRelativeHorizontalInput = playerHorizontalInput * right;

            //Create and apply camera relative movement
            Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;

            //this.transform.Translate(cameraRelativeMovement, Space.World);
            _direction2 = cameraRelativeMovement;
        }


    }

    public void OnPause(bool value)
    {
        isPaused = value;
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("We have Jumped");
    }


    private void Update()
    {
        if (!isPaused) 
        {
            ApplyMovement();
        }

        hasEventBeenTriggered = false;
    }

    private void ApplyRotation()
    {/*
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
       
        currentAngle = angle;
        //Debug.Log(currentAngle);*/

        //transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        hasMoved = false;
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
            _direction2.y = 0;
        }
        else
        {  
            _velocity += _gravity * gravityMultiplyer * Time.deltaTime;
            _direction2.y = _velocity;
        }
       
    }

    private void ApplyMovement()
    {

        if (!_characterController.isGrounded)
            ApplyGravity();
     

        if (_input.x != 0.0f || _input.y != 0.0f)
        {
            PlayFootstep();
          
            _characterController.Move(_direction2 * speed);

            Transform puffFacing = puffPlayer[0].GetComponent<Transform>();
            _direction2.y = 0;
            transform.rotation = Quaternion.LookRotation(_direction2);
            //_characterController.Move(_direction2 * speed);
            hasMoved = true;
        }   
    }

    public void GroundMaterialSwitch(string switchName)
    {

        AkSoundEngine.SetSwitch("GroundMaterial", switchName, gameObject);
        PlayFootstep();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Dirt"))
        {
            GroundMaterialSwitch("Dirt");
        }
        else if (other.CompareTag("Grass"))
        {
            GroundMaterialSwitch("Grass");
        }

    }
    void PlayFootstep()
    {

        //Should check if player is on ground here to see if it is needed to be played
        if (Play_Footstep != null)
        {
           
            Play_Footstep.Post(gameObject);
            hasEventBeenTriggered = true;
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
}
