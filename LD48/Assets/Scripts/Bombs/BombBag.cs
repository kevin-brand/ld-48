using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bombs
{
    public class BombBag : MonoBehaviour
    {
        [SerializeField] private Bomb bombPrefab;
        [SerializeField] private BombData defaultBomb;
        [SerializeField] private BombSlot slotOne;
        [SerializeField] private BombSlot slotTwo;
        [SerializeField] private LayerMask cantPlaceOn;
        [SerializeField] private float bombCooldown;

        private void Awake()
        {
            slotOne.SetBomb(defaultBomb);
            slotTwo.SetBomb(defaultBomb);
        }

        public void OnBombOneInput(InputAction.CallbackContext context)
        {
            if (context.started)
                AttemptToPlaceBomb(slotOne);
        }
        
        public void OnBombTwoInput(InputAction.CallbackContext context)
        {
            if (context.started)
                AttemptToPlaceBomb(slotTwo);
        }

        private void AttemptToPlaceBomb(BombSlot slot)
        {
            if (slot.held <= 0)
                slot.SetBomb(defaultBomb);
            
            Vector2 targetLocation = new Vector2();

            if (AttemptToGetAndSetNearestValidPlacingPosition(ref targetLocation))
            {
                Bomb bomb = Instantiate(bombPrefab);
                bomb.Place(targetLocation, slot.Bomb);
                
                if (slot.Bomb.isLimited)
                    slot.held--;
            }
        }

        private bool AttemptToGetAndSetNearestValidPlacingPosition(ref Vector2 v)
        {
            float x = Mathf.RoundToInt(transform.position.x);
            float y = Mathf.RoundToInt(transform.position.y);

            Vector2 nearestPoint = new Vector2(x, y);

            if (Physics2D.OverlapPoint(nearestPoint, cantPlaceOn) == null)
            {
                v = nearestPoint;
                return true;
            }
            
            return false;
        }
    }
}
