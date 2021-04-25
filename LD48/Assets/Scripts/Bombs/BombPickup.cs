using System;
using System.Collections;
using System.Collections.Generic;
using Bombs;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombPickup : MonoBehaviour
{
    [SerializeField] private BombData bomb;

    private bool _playerIsInTriggerRange = false;
    private BombBag _bag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter");
        if (other.GetComponent<BombBag>())
        {
            Debug.Log("Found Player");
            _playerIsInTriggerRange = true;
            _bag = other.GetComponent<BombBag>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<BombBag>())
        {
            _playerIsInTriggerRange = false;
            _bag = null;
        }
    }
    
    public void OnBombOneInput(InputAction.CallbackContext context)
    {
        if (context.started && _playerIsInTriggerRange)
            _bag.SetBombInSlot(bomb, 0);
    }
        
    public void OnBombTwoInput(InputAction.CallbackContext context)
    {
        if (context.started && _playerIsInTriggerRange)
            _bag.SetBombInSlot(bomb, 1);
    }
}
