using System;
using Character.FSM;
using UnityEngine;

namespace Character
{
    public class Controller : MonoBehaviour
    {
        public StateMachine StateMachine { get; private set; }
        public Animator Anim { get; private set; }

        [SerializeField] private Animator spriteChild;
        
        private void Awake()
        {
            StateMachine = new StateMachine();

            if (spriteChild != null)
                Anim = spriteChild.GetComponent<Animator>();
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
