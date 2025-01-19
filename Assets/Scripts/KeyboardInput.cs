using ProjectFish.Movement;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInputSource
{
    [Header("Input")]
    [SerializeField] private Vector3 moveDirection;    
    [SerializeField] private Vector2 lookDirection;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isJumping;

    //[Header("Keybinds")]
    // TODO: Add a SerializedDictionary or other method to change keyBindings
    public Vector3 GetMovementInput()
    {
        return moveDirection.normalized;
    }

    public Vector2 GetLookInput()
    {
        return lookDirection;
    }

    public bool GetRunInput() => isRunning;

    public bool GetJumpInput() => isJumping;

    private void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");
        
        lookDirection.x = Input.GetAxis("Mouse X");
        lookDirection.y = Input.GetAxis("Mouse Y");
        
        isJumping = Input.GetKey(KeyCode.Space);
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }
}
