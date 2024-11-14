using System;
using UnityEngine;

namespace Implementation.Player.AI
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyStrategyController : MonoBehaviour, IEnemyStrategyHandler
    {
        private Rigidbody _rigidbody;
        [SerializeField]
        private SightController _sightController;

        private DefaultEnemyStrategy _defaultEnemyStrategy;

        private IEnemyStrategy _currentEnemyStrategy;

        [field: SerializeField]
        public Collider SightCollider { get; private set; }

        public IEnemyStrategy Strategy
        {
            get => _currentEnemyStrategy;
            set => _currentEnemyStrategy = value;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            if (_sightController == null)
            {
                throw new NullReferenceException("SightController is not provided.");
            }

            _defaultEnemyStrategy = new DefaultEnemyStrategy();

            _sightController.OnCollisionEnterEvents.AddListener(HandleColliderEnter);
            _sightController.OnCollisionExitEvents.AddListener(HandleColliderExit);
        }

        private void Start()
        {
            _currentEnemyStrategy = _defaultEnemyStrategy;
        }

        private void HandleColliderEnter(Collider collider)
        {
            if (!collider.gameObject.CompareTag("Player"))
            {
                return;
            }
            OnPlayerEnter(collider);
        }

        private void HandleColliderExit(Collider collider)
        {
            if (!collider.gameObject.CompareTag("Player"))
            {
                return;
            }
            OnPlayerExit();
        }

        private void OnPlayerEnter(Collider collider)
        {
            if (_currentEnemyStrategy is PlayerChaseEnemyStrategy)
            {
                return;
            }
            GameObject targetObject = collider.gameObject;
            _currentEnemyStrategy = new PlayerChaseEnemyStrategy(targetObject, _rigidbody);
            Debug.Log("Player entered sight");
        }

        public void OnPlayerExit()
        {
            if (_currentEnemyStrategy == _defaultEnemyStrategy)
            {
                return;
            }
            _currentEnemyStrategy = _defaultEnemyStrategy;
            Debug.Log("Player exited sight");
        }

        private void Update()
        {
            if (_currentEnemyStrategy == null)
            {
                return;
            }
            _currentEnemyStrategy.Update();
        }

        private void FixedUpdate()
        {
            if (_currentEnemyStrategy == null)
            {
                return;
            }
            _currentEnemyStrategy.FixedUpdate();
        }
    }
}
