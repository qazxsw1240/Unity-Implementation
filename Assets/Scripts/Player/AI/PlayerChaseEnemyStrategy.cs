using System.Collections.Generic;
using Implementation.Entity;
using Implementation.Player.Inventory;
using UnityEngine;

namespace Implementation.Player.AI
{
    public class PlayerChaseEnemyStrategy : IEnemyStrategy
    {
        private readonly GameObject _targetObject;
        private readonly Transform _targetTransform;
        private readonly Rigidbody _rigidbody;
        private readonly PlayerInventoryComponent _playerInventoryComponent;

        private bool _inventoryEventActivated;

        public PlayerChaseEnemyStrategy(GameObject targetObject, Rigidbody originRigidbody)
        {
            _targetObject = targetObject;
            _targetTransform = _targetObject.transform;
            _rigidbody = originRigidbody;
            _playerInventoryComponent = _targetObject.GetComponent<PlayerInventoryComponent>();
            _inventoryEventActivated = false;
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
            Vector3 currentPosition = _rigidbody.position;
            Vector3 rotationVector = (_targetTransform.position - currentPosition).normalized;
            _rigidbody.position += rotationVector * (1.5f * Time.fixedDeltaTime);
            if ((_rigidbody.position - _targetTransform.position).sqrMagnitude < 1)
            {
                if (!_inventoryEventActivated)
                {

                    _playerInventoryComponent.Inventory.Add(new DemoEntity());
                    Debug.Log("Entity added to inventory");
                    _inventoryEventActivated = true;
                }
            }
            else
            {
                _inventoryEventActivated = false;
            }
        }
    }
}
