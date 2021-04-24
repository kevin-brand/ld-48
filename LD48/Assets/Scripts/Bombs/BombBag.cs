using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bombs
{
    public class BombBag : MonoBehaviour
    {
        [SerializeField] private Bomb bombPrefab;
        [SerializeField] private BombData defaultBomb;
        [SerializeField] private BombData bombOne;
        [SerializeField] private BombData bombTwo;
        [SerializeField] private LayerMask cantPlaceOn;
        private int _bombOneHeld;
        private int _bombTwoHeld;
        
        private void Awake()
        {
            if (bombOne == null)
                bombOne = defaultBomb;

            if (bombTwo == null)
                bombTwo = defaultBomb;
        }

        public void OnBombOneInput(InputAction.CallbackContext context)
        {
            Debug.Log("Attempting to place Bomb 1");
            if (context.started)
                AttemptToPlaceBomb(bombOne);
        }
        
        public void OnBombTwoInput(InputAction.CallbackContext context)
        {
            if (context.started)
                AttemptToPlaceBomb(bombTwo);
        }

        private void AttemptToPlaceBomb(BombData bombData)
        {
            Vector2 targetLocation = new Vector2();

            if (AttemptToGetAndSetNearestValidPlacingPosition(ref targetLocation))
            {
                Bomb bomb = Instantiate(bombPrefab);
                bomb.Place(targetLocation, bombData);
                return;
            }
            
            Debug.Log("CAN'T PLACE A BOMB HERE");
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
