using System.Collections;
using UnityEngine;

namespace Utility
{
    public class HitStop : MonoBehaviour
    {
        private bool _timeStopped = false;
        
        public void StopTime(float hitStopDuration)
        {
            if (_timeStopped)
                return;
            
            Time.timeScale = 0.01f;
            StartCoroutine(Wait(hitStopDuration));
        }

        private IEnumerator Wait(float hitStopDuration)
        {
            _timeStopped = true;
            yield return new WaitForSecondsRealtime(hitStopDuration);
            Time.timeScale = 1.0f;
            _timeStopped = false;
        }
    }
}
