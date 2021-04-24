using System;
using Character.FSM;
using Character.FSM.States.SubStates;
using UnityEngine;

namespace Character
{
    public class Controller : MonoBehaviour
    {
        public StateMachine StateMachine { get; private set; }
        public Animator Anim { get; private set; }
        
        public IdleState IdleState { get; private set; }
        public MoveState MoveState { get; private set; }
        

        [SerializeField] private Animator spriteChild;
        [SerializeField] private MovementData movementData;
        
        private void Awake()
        {
            StateMachine = new StateMachine();

            IdleState = new IdleState(this, StateMachine, movementData, "idle");
            MoveState = new MoveState(this, StateMachine, movementData, "move");

            if (spriteChild != null)
                Anim = spriteChild.GetComponent<Animator>();
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
    }
}
