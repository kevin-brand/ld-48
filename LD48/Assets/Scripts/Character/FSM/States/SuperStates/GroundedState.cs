using UnityEngine;

namespace Character.FSM.States.SuperStates
{
    public class GroundedState : State
    {
        protected float MoveInput;
        private bool _jumpInput;
        
        public GroundedState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            MoveInput = Controller.InputHandler.MovementInput;
            _jumpInput = Controller.InputHandler.JumpInput;

            if (_jumpInput)
            {
                StateMachine.ChangeState(Controller.JumpState);
                Controller.InputHandler.ResetJumpInput();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
