using Character.FSM.States.SuperStates;

namespace Character.FSM.States.SubStates
{
    public class MoveState : GroundedState
    {
        public MoveState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }
    }
}
