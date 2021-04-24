namespace Character.FSM.States.SuperStates
{
    public class AbilityState : State
    {
        protected bool IsAbilityDone;
        
        public AbilityState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            IsAbilityDone = false;
        }
    }
}