using UnityEngine;

namespace Character.FSM.States.SuperStates
{
    public class GroundedState : State
    {
        public GroundedState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }
    }
}
