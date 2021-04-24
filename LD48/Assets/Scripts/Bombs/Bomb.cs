using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Bombs
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private BombData debugBombData;
        [SerializeField] private GameObject warningEffect;
        
        private SpriteRenderer _renderer;
        private int _fuseTime;
        private bool _ticking = false;

        private bool _hasBeenInitialized = false;

        private List<Vector2> _explosionPositions;
        private BombData _data;
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (debugBombData)
                Place(this.transform.position, debugBombData);
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
            
            _ticking = false;
        }

        public void Place(Vector2 position, BombData data)
        {
            _data = data;
            _renderer.sprite = _data.sprite;
            _fuseTime = _data.fuseTime;
            
            transform.position = position;
            _explosionPositions = _data.pattern.GetExplosionPositions(position);
            DisplayWarningEffect();
            
            _hasBeenInitialized = true;
        }

        private void DisplayWarningEffect()
        {
            foreach (var detonationPosition in _explosionPositions)
            {
                Vector3 detonationWorldPosition = new Vector3(detonationPosition.x, detonationPosition.y, 0);
                Instantiate(warningEffect, detonationWorldPosition, Quaternion.identity, this.transform);
            }
        }

        private void Detonate()
        {
            foreach (var detonationPosition in _explosionPositions)
            {
                Debug.Log("Checking at: " + detonationPosition.ToString());
                Collider2D hit = Physics2D.OverlapPoint(detonationPosition, _data.whatIsAffected);
                Debug.Log("Found: " + hit);
                if (hit != null && hit.GetComponent<IDamageable>() != null)
                {
                    hit.GetComponent<IDamageable>().ReceiveDamage(_data.damage);
                }
            }
            
            Destroy(this.gameObject);
        }
    }
}
