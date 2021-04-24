namespace Character.FSM.States.SuperStates
{
    public class AbilityState : State
    {
        public AbilityState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }
    }
}