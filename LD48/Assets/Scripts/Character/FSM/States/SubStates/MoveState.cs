using System;
using Character.FSM.States.SuperStates;
using UnityEngine;

namespace Character.FSM.States.SubStates
{
    public class MoveState : GroundedState
    {
        public MoveState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();

            float rawMoveInput = MoveInput;
            float normalizedMoveInput = Mathf.RoundToInt(rawMoveInput);
            float direction = (MovementData.allowAnalogMoveSpeed) ? rawMoveInput : normalizedMoveInput;
            
            Controller.SetVelocityX(MovementData.movementSpeed * direction);

            Controller.UpdateFacingDirection();
            
            // Check Exit Conditions
            if (Mathf.Abs(MoveInput) < Mathf.Epsilon)
            {
                StateMachine.ChangeState(Controller.IdleState);
            }
        }
    }
}
