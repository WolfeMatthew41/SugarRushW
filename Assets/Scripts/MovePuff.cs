using UnityEngine;
using UnityEngine.InputSystem;

public class MovePuff : MonoBehaviour
{
    [SerializeField]
    private float speed = .05f; //Used to control speed of Puff

    [SerializeField]
    private float fallSpeed = -.098f; //Used to control speed of Puff

    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private InputActionReference jump;

    private Vector2 _moveInput;

    [SerializeField]
    private Transform _moveOrientation;

    private Transform _baseOrientation;

    [SerializeField]
    private Rigidbody _rb;

    private CharacterController _characterController;
    // Jump Variables
    private Vector3 _playerVelocity;

    public float _playerSize = 0.4f;

    private bool _groundedPlayer;

    private float _jumpHeight = 5.0f;

    private bool _jumpPressed = false;

    private float _gravityValue = -.0981f;

    private GameObject playerObj = null;

    // Start is called before the first frame update
    void start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;

        _baseOrientation = _moveOrientation.transform;

        playerObj = GameObject.Find("Puff");
        _characterController = GetComponent < CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        //Vector3 moveDirection = new Vector3(_moveInput.x, 0.0f, _moveInput.y);

        Vector3 moveDirection = _moveOrientation.forward * _moveInput.y + _moveOrientation.right * _moveInput.x;

        _rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        //transform.position += moveDirection * speed;

        _moveOrientation.rotation = _baseOrientation.rotation;

    }


    private void OnJump()
    {
        Debug.Log("We have Jumped");
        

    }
}
