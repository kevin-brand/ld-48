using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Bombs
{
    public class Bomb : MonoBehaviour, IDamageable
    {

        [SerializeField] private BombData staticBomb;
        [SerializeField] private GameObject warningEffect;

        private SpriteRenderer _renderer;
        private int _fuseTime;
        private bool _ticking = false;

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
            
            if (!_ticking && _fuseTime > 0)
            {
                StartCoroutine(Tick());
            }
        }
        
        private IEnumerator Tick()
        {
            _ticking = true;
            yield return new WaitForSeconds(1);
            _fuseTime--;
            
            //Display Timer here
            
            if (_fuseTime == 0)
                Detonate();
            
            if (_fuseTime == _data.timeToDisplayWarningEffectAt)
                DisplayWarningEffect();
            
            _ticking = false;
        }

        public void Place(Vector2 position, BombData data)
        {
            _data = data;
            _renderer.sprite = _data.sprite;
            _fuseTime = _data.fuseTime;
            
            transform.position = position;
            _explosionPositions = _data.pattern.GetExplosionPositions(position);

            _hasBeenInitialized = true;
        }

        private void DisplayWarningEffect()
        {
            if (warningEffect == null)
                return;
            
            foreach (var detonationPosition in _explosionPositions)
            {
                Vector3 detonationWorldPosition = new Vector3(detonationPosition.x, detonationPosition.y, 0);
                Instantiate(warningEffect, detonationWorldPosition, Quaternion.identity, this.transform);
            }
        }

        private void Detonate()
        {
            if(_exploding)
                return;

            _exploding = true;
            
            foreach (var detonationPosition in _explosionPositions)
            {
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
