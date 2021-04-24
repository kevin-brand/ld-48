using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class InputHandler : MonoBehaviour
    {
        private float _movementInput;
        
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            _movementInput = context.ReadValue<float>();
            Debug.Log(_movementInput);
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            
        }
    }
}
