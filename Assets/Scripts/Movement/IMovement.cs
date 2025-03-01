using UnityEngine;

namespace ProjectFish.Movement
{
    public interface IMovement
    {
        public void Move(Vector3 direction, bool isRunning);
        public void Rotate(Vector2 direction);
        public void ApplyGravity(bool isJumping);

    }
}

