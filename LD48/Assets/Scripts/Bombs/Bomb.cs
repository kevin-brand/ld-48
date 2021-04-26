using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Bombs
{
    public class Bomb : MonoBehaviour, IDamageable
    {

        [SerializeField] private BombData staticBomb;
        
        [SerializeField] private GameObject warningEffect;
        [SerializeField] private GameObject explosionEffect;
        public UnityEvent screenShakeEvent;
        public GameObject AudioExplosion;

        private SpriteRenderer _renderer;
        private float _fuseTime;
        private bool _ticking = false;
        private bool _displayedWarningEffects = false;

        private bool _hasBeenInitialized = false;
        private bool _exploding = false;

        private List<Vector2> _explosionPositions;
        private BombData _data;
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (staticBomb)
            {
                _data = staticBomb;
                _explosionPositions = _data.pattern.GetExplosionPositions(transform.position);
            }
        }

        private void Update()
        {
            if(!_hasBeenInitialized)
                return;

            _fuseTime -= Time.deltaTime;
            if (_fuseTime <= 0)
                Detonate();
            
            if (_fuseTime <= 1f)
                DisplayWarningEffect();
        }

        public void Place(Vector2 position, BombData data)
        {
            _data = data;
            _fuseTime = _data.fuseTime;
            Debug.Log("Fuse Time: " + _fuseTime);
            
            transform.position = position;
            _explosionPositions = _data.pattern.GetExplosionPositions(position);

            _hasBeenInitialized = true;
        }

        private void DisplayWarningEffect()
        {
            if (warningEffect == null || _displayedWarningEffects)
                return;
            
            foreach (var detonationPosition in _explosionPositions)
            {
                Vector3 detonationWorldPosition = new Vector3(detonationPosition.x, detonationPosition.y, 0);
                Instantiate(warningEffect, detonationWorldPosition, Quaternion.identity);
            }

            _displayedWarningEffects = true;
        }

        private void Detonate()
        {
            if(_exploding)
                return;

            Instantiate(AudioExplosion);
            AudioExplosion.GetComponent<AudioSource>().Play();
            _exploding = true;
            screenShakeEvent.Invoke();
            
            foreach (var detonationPosition in _explosionPositions)
            {
                if (explosionEffect)
                    Instantiate(explosionEffect, detonationPosition, Quaternion.identity);
                
                Collider2D hit = Physics2D.OverlapCircle(detonationPosition, 0.4f, _data.whatIsAffected);
                if (hit != null && hit.GetComponent<IDamageable>() != null)
                {
                    hit.GetComponent<IDamageable>().ReceiveDamage(_data.damage);
                }
            }
            
            Destroy(this.gameObject);
        }

        public void ReceiveDamage(int damage)
        {
            Detonate();
        }
    }
}
