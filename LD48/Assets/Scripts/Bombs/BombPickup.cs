using System;
using System.Collections;
using System.Collections.Generic;
using Bombs;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombPickup : MonoBehaviour
{
    [SerializeField] private BombData bomb;
    [SerializeField] public GameObject warningEffect;
    
    private bool _playerIsInTriggerRange = false;
    private BombBag _bag;

    private List<GameObject> _warningEffects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BombBag>())
        {
            DisplayWarningEffect();
            _playerIsInTriggerRange = true;
            _bag = other.GetComponent<BombBag>();
            _bag.inBombPickupTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<BombBag>())
        {
            RemoveWarningEffect();
            _playerIsInTriggerRange = false;
            _bag.inBombPickupTrigger = false;
            _bag = null;
        }
    }
    
    private void DisplayWarningEffect()
    {
        List<Vector2> positions = bomb.pattern.GetExplosionPositions(transform.position);
            
        foreach (var detonationPosition in positions)
        {
            Vector3 detonationWorldPosition = new Vector3(detonationPosition.x, detonationPosition.y, 0);
            GameObject preview = Instantiate(warningEffect, detonationWorldPosition, Quaternion.identity, this.transform);
            _warningEffects.Add(preview);
        }
    }
    
    private void RemoveWarningEffect()
    {
        if (warningEffect == null)
            return;
        
            
        foreach (var effect in _warningEffects)
        {
            Destroy(effect);
        }
        _warningEffects.Clear();
    }
    
    public void OnBombOneInput(InputAction.CallbackContext context)
    {
        if (context.started && _playerIsInTriggerRange)
        {
            _bag.SetBombInSlot(bomb, 0);
            StartCoroutine(DestroyAfterDelay());
        }
    }
        
    public void OnBombTwoInput(InputAction.CallbackContext context)
    {
        if (context.started && _playerIsInTriggerRange)
        {
            _bag.SetBombInSlot(bomb, 1);
            StartCoroutine(DestroyAfterDelay());

        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSecondsRealtime(0.02f);
        Destroy(this.gameObject);
    }
}
