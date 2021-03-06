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
        public CapsuleCollider2D Collider2D { get; private set; }
        public InputHandler InputHandler { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }

        // Julian's lazy sound properties
        public AudioSource SoundStep;
        public AudioSource SoundJump;
        public AudioSource SoundHurt;
        public AudioSource SoundDeath;


        // Ground States
        public IdleState IdleState { get; private set; }
        public MoveState MoveState { get; private set; }
        public LandState LandState { get; private set; }
        
        // Ability States
        public JumpState JumpState { get; private set; }
        public AirState AirState { get; private set; }
        public DeathState DeathState { get; private set; }
        
        // Serialized Fields
        [SerializeField] private MovementData movementData;

        private Vector2 _velocity;
        
        private void Awake()
        {
            StateMachine = new StateMachine();

            IdleState = new IdleState(this, StateMachine, movementData, "idle");
            MoveState = new MoveState(this, StateMachine, movementData, "move");
            LandState = new LandState(this, StateMachine, movementData, "land");
            JumpState = new JumpState(this, StateMachine, movementData, "jump");
            AirState = new AirState(this, StateMachine, movementData);
            DeathState = new DeathState(this, StateMachine, movementData);
            
            Anim = GetComponent<Animator>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Collider2D = GetComponent<CapsuleCollider2D>();
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

        public bool CheckIfTouchingGround()
        {
            Vector2 groundCheckPosition = transform.position - new Vector3(0, Collider2D.size.y / 2f);

            return Physics2D.OverlapCircle(groundCheckPosition, movementData.groundCheckRadius, movementData.whatIsGround);
        }

        public void SetVelocityX(float velocity)
        {
            _velocity.Set(velocity, CurrentVelocity.y);
            Rigidbody2D.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void SetVelocityY(float velocity)
        {
            _velocity.Set(CurrentVelocity.x, velocity);
            Rigidbody2D.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void UpdateFacingDirection()
        {
            int xInput = Mathf.RoundToInt(InputHandler.MovementInput);
            if (xInput != 0 && xInput != FacingDirection)
                Flip();
        }

        public void PlaySound(string sound)
        {
            switch (sound)
            {
                case "step":
                    SoundStep.Play();
                    break;
                case "jump":
                    SoundJump.Play();
                    break;
                case "hurt":
                    SoundHurt.Play();
                    break;
                case "death":
                    SoundDeath.Play();
                    break;
                default:
                    break;
            }
        }


        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
