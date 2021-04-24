namespace Character.FSM
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(State nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            CurrentState.Enter();
        }
    }
}
