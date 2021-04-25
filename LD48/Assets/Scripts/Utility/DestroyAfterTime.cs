using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utility
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float maxTimeUntilSelfDestruction = 5f;
        [SerializeField] [Range(0f, 1f)] private float delayMargin = 0.05f;

        private float _timeUntilSelfDestruction;

        private void Start()
        {
            _timeUntilSelfDestruction = maxTimeUntilSelfDestruction * Random.Range(1f - delayMargin, 1f + delayMargin);
        }

        private void Update()
        {
            _timeUntilSelfDestruction -= Time.deltaTime;
            
            if (_timeUntilSelfDestruction <= 0)
                Destroy(this.gameObject);
        }
    }
}
