using Character.FSM.States.SuperStates;
using UnityEngine;

namespace Character.FSM.States.SubStates
{
    public class IdleState : GroundedState
    {
        public IdleState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Controller.SetVelocityX(0f);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Mathf.Abs(MoveInput) > Mathf.Epsilon)
            {
                StateMachine.ChangeState(Controller.MoveState);
            }
        }
    }
}
