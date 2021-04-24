using Character.FSM.States.SuperStates;

namespace Character.FSM.States.SubStates
{
    public class LandState : GroundedState
    {
        public LandState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }
    }
}