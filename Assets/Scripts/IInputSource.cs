using UnityEngine;

namespace ProjectFish.Movement
{
    public interface IInputSource
    {
        public Vector3 GetMovementInput();
        public Vector2 GetLookInput();
        public bool GetRunInput();
        public bool GetJumpInput();
    }
}