using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Character
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 6;
        [SerializeField] private float invulnerableTime = 0.5f;
        [SerializeField] private float hitStopDuration = 0.2f;
        
        public int Health => health;

        private float _invulnerableTimeRemaining = 0f;
        private Controller _controller;
        private bool _dead;

        private bool _timeStopped = false;

        private void Awake()
        {
            _controller = GetComponent<Controller>();
        }

        private void Start()
        {
            _dead = false;
        }

        private void Update()
        {
            if (_invulnerableTimeRemaining > 0f)
                _invulnerableTimeRemaining -= Time.deltaTime;
        }

        public void ReceiveDamage(int damage)
        {
            if (_invulnerableTimeRemaining > 0f)
                return;
            
            health -= damage;
            StopTime();
            
            if (health <= 0)
                Die();
                
            
            _invulnerableTimeRemaining = invulnerableTime;
        }

        private void StopTime()
        {
            if (_timeStopped)
                return;
            
            Time.timeScale = 0.01f;
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            _timeStopped = true;
            yield return new WaitForSecondsRealtime(hitStopDuration);
            Time.timeScale = 1.0f;
            _timeStopped = false;
        }

        private void Die()
        {
            if (_dead)
                return;
            
            _controller.StateMachine.ChangeState(_controller.DeathState);
            _dead = true;
        }
    }
}