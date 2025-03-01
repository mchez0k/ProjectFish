using ProjectFish.InputSource;
using ProjectFish.InventorySystem;
using ProjectFish.Movement;
using UnityEngine;

namespace ProjectFish.Player
{
    public class Player : MonoBehaviour
    {
        private IInputSource moveInput;
        private IMovement playerMovement;
        private PlayerInventory inventory;
        [SerializeField] private Transform playerEyes;

        public void Awake()
        {
            moveInput = GetComponent<KeyboardInput>();
            playerMovement = GetComponent<PlayerMovement>();
            inventory = new PlayerInventory(gameObject, playerEyes);
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            playerMovement.Move(moveInput.GetMovementInput(), moveInput.GetRunInput());
            playerMovement.Rotate(moveInput.GetLookInput());
            playerMovement.ApplyGravity(moveInput.GetJumpInput());

            if (Input.GetKeyDown(KeyCode.E))
                inventory.TryPickupItem();


            if (Input.GetKeyDown(KeyCode.G))
                inventory.DropItem(0);

            Debug.DrawRay(playerEyes.position, playerEyes.forward * inventory.MaxDistance, Color.green);
        }
    }
}