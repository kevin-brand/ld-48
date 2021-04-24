namespace Character.FSM.States.SubStates
{
    public class AirState : State
    {
        public AirState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }
    }
}