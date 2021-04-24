using UnityEngine;

namespace Character.FSM
{
    public class State
    {
        protected Controller Controller;
        protected StateMachine StateMachine;
        protected MovementData MovementData;

        protected float StartTime;
        private string _animBoolName;

        public State(Controller controller, StateMachine stateMachine, MovementData movementData, string animBoolName = "")
        {
            Controller = controller;
            StateMachine = stateMachine;
            MovementData = movementData;
            _animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            
            if (Controller.Anim != null && _animBoolName != "")
                Controller.Anim.SetBool(_animBoolName, true);
            
            StartTime = Time.time;
        }

        public virtual void Exit()
        {
            if (Controller.Anim != null)
                Controller.Anim.SetBool(_animBoolName, false);
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            
        }
    }
}
