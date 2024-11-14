using UnityEngine;

namespace Implementation.Player.AI
{
    public class PlayerChaseEnemyStrategy : IEnemyStrategy
    {
        private readonly GameObject _targetObject;
        private readonly Transform _targetTransform;
        private readonly Rigidbody _rigidbody;

        public PlayerChaseEnemyStrategy(GameObject targetObject, Rigidbody originRigidbody)
        {
            _targetObject = targetObject;
            _targetTransform = _targetObject.transform;
            _rigidbody = originRigidbody;
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
            Vector3 currentPosition = _rigidbody.position;
            Vector3 rotationVector = (_targetTransform.position - currentPosition).normalized;
            _rigidbody.position += rotationVector * (1.5f * Time.fixedDeltaTime);
        }
    }
}
