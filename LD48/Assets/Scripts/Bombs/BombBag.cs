using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bombs
{
    public class BombBag : MonoBehaviour
    {
        [SerializeField] private Bomb bombPrefab;
        [SerializeField] private BombData defaultBomb;
        [SerializeField] private BombSlot[] slots = new BombSlot[2];
        [SerializeField] private LayerMask cantPlaceOn;
        [SerializeField] private float bombCooldown;

        private void Awake()
        {
            slots[0].SetBomb(defaultBomb);
            slots[1].SetBomb(defaultBomb);
        }

        public void OnBombOneInput(InputAction.CallbackContext context)
        {
            if (context.started)
                AttemptToPlaceBomb(slots[0]);
        }
        
        public void OnBombTwoInput(InputAction.CallbackContext context)
        {
            if (context.started)
                AttemptToPlaceBomb(slots[1]);
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

        public void SetBombInSlot(BombData bomb, int slotIndex)
        {
            if (slotIndex < slots.Length)
            {
                slots[slotIndex].SetBomb(bomb);
            }
        }
    }
}
