using ProjectFish.Movement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{   
    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float maxFallSpeed = 30f;
    [Header("Look")]
    [SerializeField] private float sensitivity;
    [SerializeField] private float topClamp;
    [SerializeField] private float bottomClamp;
    [SerializeField] private Transform cameraTransform;
    private float xRotation = 0f;

    [Header("Gravity")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private Transform legPosition;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float verticalVelocity = 0f;
    
    [Header("Components")]
    [SerializeField] private CharacterController characterController;
    public void Move(Vector3 direction, bool isRunning)
    {
        Vector3 moveDirection = transform.TransformDirection(direction);
        float speed = (isRunning ? runSpeed : moveSpeed) * Time.deltaTime;
        characterController.Move(moveDirection * speed);
    }

    public void Rotate(Vector2 direction)
    {
        xRotation -= direction.y;
        xRotation = Mathf.Clamp(xRotation, bottomClamp, topClamp);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * direction.x);
    }

    public void ApplyGravity(bool isJumping)
    {
        if (IsGrounded())
        {
            verticalVelocity = -0.5f;
            if (isJumping) verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
            verticalVelocity = Mathf.Max(verticalVelocity, -maxFallSpeed);
        }

        characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        Ray ray = new Ray(legPosition.position, Vector3.down);
        return Physics.Raycast(ray, groundCheckDistance, groundLayer);
    }
}