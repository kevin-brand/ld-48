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
            Bomb bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            bomb.Place(GetNearestValidPlacingPosition(), bombData);
        }

        private Vector2 GetNearestValidPlacingPosition()
        {
            float x = Mathf.RoundToInt(transform.position.x);
            float y = Mathf.RoundToInt(transform.position.y);

            Vector2 nearestPoint = new Vector2(x, y);
            
            if(Physics2D.OverlapPoint(nearestPoint) == null)
                return nearestPoint;

            return nearestPoint;

        }
    }
}
