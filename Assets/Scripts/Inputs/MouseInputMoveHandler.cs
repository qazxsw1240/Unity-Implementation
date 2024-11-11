using System;
using Implementation.Player;
using UnityEngine;

namespace Implementation.Inputs
{
    public class MouseInputMoveHandler : MonoBehaviour, IMouseEventHandler
    {
        private Rigidbody _rigidBody;
        private PlayerPropertyCollection _propertyCollection;

        private bool _isIdle = true;
        private bool _isPreviousPositionCapture = false;
        private Vector3 _targetPosition = Vector3.zero;
        private Vector3 _previousPosition;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _propertyCollection = GetComponent<PlayerPropertyCollection>();
        }

        private void FixedUpdate()
        {
            if (_isIdle)
            {
                return;
            }
            float epsilon = Time.fixedDeltaTime * _propertyCollection.Speed + Mathf.Epsilon;
            float vectorEpsilon = epsilon * 3 + Mathf.Epsilon;
            float epsilonSquare = epsilon * epsilon + Mathf.Epsilon;
            Vector3 currentPosition = _rigidBody.position;
            Vector3 distanceVector = _targetPosition - currentPosition;
            float vectorOffset = Mathf.Abs(currentPosition.sqrMagnitude - _previousPosition.sqrMagnitude);
            Debug.LogFormat("vector offset: {0}", vectorOffset);
            Debug.LogFormat("distanceVector offset: {0}", distanceVector.magnitude);
            if ((_isPreviousPositionCapture && vectorOffset < epsilonSquare) || distanceVector.magnitude < vectorEpsilon)
            {
                Debug.Log("Player move finished");
                _isIdle = true;
                _isPreviousPositionCapture = false;
                return;
            }
            Vector3 rotationVector = (_targetPosition - currentPosition).normalized;
            _previousPosition = _rigidBody.position;
            _rigidBody.position += rotationVector * (_propertyCollection.Speed * Time.fixedDeltaTime);
            _isPreviousPositionCapture = true;
        }

        public void OnMouseClick(MouseButtons button, MouseEvent mouseEvent)
        {
            Vector3 targetPosition = mouseEvent.TargetPosition;
            targetPosition.y = mouseEvent.OriginPosition.y;
            _isIdle = false;
            _targetPosition = targetPosition;
        }
    }
}
