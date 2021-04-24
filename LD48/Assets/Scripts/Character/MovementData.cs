using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "new Character Movement Data", menuName = "Data/Character/Movement Data")]
    public class MovementData : ScriptableObject
    {
        [Header("Move State")] 
        public float movementSpeed = 10;
        public bool allowAnalogMoveSpeed = false;

        [Header("Jump State")] 
        public float jumpVelocity = 15f;
    }
}
