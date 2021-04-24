using Character.FSM.States.SuperStates;

namespace Character.FSM.States.SubStates
{
    public class JumpState : AbilityState
    {
        public JumpState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Controller.SetVelocityY(MovementData.jumpVelocity);
            StateMachine.ChangeState(Controller.AirState);
        }

        public override void Exit()
        {
            base.Exit();
            IsAbilityDone = true;
        }
    }
}