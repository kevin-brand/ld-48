using UnityEngine;

namespace Character.FSM.States.SubStates
{
    public class DeathState : State
    {
        public DeathState(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "") : base(controller, stateMachine, movementData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("I dieded");
        }
    }
}