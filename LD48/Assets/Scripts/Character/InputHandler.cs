using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class InputHandler : MonoBehaviour
    {
        public float MovementInput { get; private set; }
        public bool JumpInput { get; private set; }
        
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<float>();
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
                JumpInput = true;
        }

        public void ResetJumpInput() => JumpInput = false;
    }
}
