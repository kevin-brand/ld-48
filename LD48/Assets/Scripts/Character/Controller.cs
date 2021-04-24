using System;
using Character.FSM;
using Character.FSM.States.SubStates;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(InputHandler), typeof(Rigidbody2D))]
    public class Controller : MonoBehaviour
    {
        // Properties
        public StateMachine StateMachine { get; private set; }
        public Animator Anim { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public InputHandler InputHandler { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }


        // States
        public IdleState IdleState { get; private set; }
        public MoveState MoveState { get; private set; }
        
        // Serialized Fields
        [SerializeField] private GameObject spriteChild;
        [SerializeField] private MovementData movementData;

        private Vector2 _velocity;
        
        private void Awake()
        {
            StateMachine = new StateMachine();

            IdleState = new IdleState(this, StateMachine, movementData, "idle");
            MoveState = new MoveState(this, StateMachine, movementData, "move");

            if (spriteChild != null)
                Anim = spriteChild.GetComponent<Animator>();

            Rigidbody2D = GetComponent<Rigidbody2D>();

            InputHandler = GetComponent<InputHandler>();
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
            FacingDirection = 1;
        }

        private void Update()
        {
            CurrentVelocity = Rigidbody2D.velocity;
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        public void SetVelocityX(float velocity)
        {
            _velocity.Set(velocity, CurrentVelocity.y);
            Rigidbody2D.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void Flip()
        {
            FacingDirection *= -1;
            spriteChild.transform.Rotate(0f, 180f, 0f);
        }
    }
}
