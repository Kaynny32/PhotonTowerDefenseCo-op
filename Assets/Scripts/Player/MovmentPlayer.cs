using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovmentPlayer : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField]
    Animator _animator;

    [Header("Key Settings")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Walk Settings")]
    [SerializeField]
    float walkSpeed = 4f;
    [SerializeField]
    float walkAcceleration = 20f;

    [Header("Sprint Settings")]
    [SerializeField]
    float sprintSpeed = 8f;
    [SerializeField]
    float sprintAcceleration = 40f;

    [Header("Jump Settings")]
    [SerializeField]
    float jumpForce = 7f;
    [SerializeField]
    float groundCheckDistance = 1.1f;
    [SerializeField]
    LayerMask groundMask;

    [Header("General")]
    [SerializeField]
    float maxSpeed = 8f;

    private Vector2 _input;
    private Rigidbody _rigidbody;

    private bool isSprinting;
    private bool jumpPressed;
    private bool isJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.drag = 4f;
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        isSprinting = Input.GetKey(sprintKey);
        jumpPressed = Input.GetKeyDown(jumpKey);

        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        ApplyMovement();

        if (jumpPressed && IsGrounded())
        {
            Jump();
        }

        isJumping = !IsGrounded();
    }

    void ApplyMovement()
    {
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;
        float currentAcceleration = isSprinting ? sprintAcceleration : walkAcceleration;

        Vector3 inputDirection = new Vector3(_input.x, 0f, _input.y);
        inputDirection = transform.TransformDirection(inputDirection);

        Vector3 desiredVelocity = inputDirection * currentSpeed;
        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocityChange = desiredVelocity - velocity;

        velocityChange = Vector3.ClampMagnitude(velocityChange, currentAcceleration * Time.fixedDeltaTime);
        velocityChange.y = 0f;

        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 flatVelocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        if (flatVelocity.magnitude > maxSpeed)
        {
            flatVelocity = flatVelocity.normalized * maxSpeed;
            _rigidbody.velocity = new Vector3(flatVelocity.x, _rigidbody.velocity.y, flatVelocity.z);
        }
    }

    void Jump()
    {
        Vector3 jumpVector = Vector3.up * jumpForce;
        _rigidbody.AddForce(jumpVector, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
    }

    void UpdateAnimator()
    {
        if (_animator == null) return;

        Vector3 flatVelocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        float horizontalSpeed = flatVelocity.magnitude;

        if (horizontalSpeed < 0.05f)
            horizontalSpeed = 0f;

        float speedNormalized = horizontalSpeed / maxSpeed;
        speedNormalized = Mathf.Clamp01(speedNormalized);

        _animator.SetFloat("Speed", speedNormalized);
        // _animator.SetBool("IsJumping", isJumping);
    }
}
