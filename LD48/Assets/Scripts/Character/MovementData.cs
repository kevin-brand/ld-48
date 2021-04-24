using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "new Character Movement Data", menuName = "Data/Character/Movement Data")]
    public class MovementData : ScriptableObject
    {
        [Header("Grounded State")] 
        public float groundCheckRadius = 0.3f;
        public LayerMask whatIsGround;
        
        [Header("Move State")] 
        public float movementSpeed = 10;
        public bool allowAnalogMoveSpeed = false;

        [Header("Jump State")] 
        public float jumpVelocity = 15f;

        [Header("Air State")] 
        [Range(0f, 1f)] public float airControlFactor = 1;
    }
}
