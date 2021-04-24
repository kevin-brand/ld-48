using System;
using UnityEngine;

namespace Character.FSM.States.SubStates
{
    public class AirState : State
    {
        private float _moveInput;
        private bool _isGrounded;
        public AirState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_isGrounded)
                StateMachine.ChangeState(Controller.LandState);

            _moveInput = Controller.InputHandler.MovementInput;
            
            float rawMoveInput = _moveInput;
            float normalizedMoveInput = Mathf.RoundToInt(rawMoveInput);
            float direction = (MovementData.allowAnalogMoveSpeed) ? rawMoveInput : normalizedMoveInput;
            
            Controller.SetVelocityX(MovementData.movementSpeed * direction * MovementData.airControlFactor);

            Controller.UpdateFacingDirection();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = Controller.CheckIfTouchingGround();
        }
    }
}