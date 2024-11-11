using System.Collections.Generic;
using Implementation.Player;
using UnityEngine;

namespace Implementation.Inputs
{
    public class DefaultMoveInputHandler : IInputActionHandler
    {
        private readonly InputProfile _inputProfile;
        private readonly PlayerPropertyCollection _propertyCollection;
        private readonly Rigidbody _rigidbody;

        public DefaultMoveInputHandler(
            InputProfile inputProfile,
            PlayerPropertyCollection propertyCollection,
            Rigidbody rigidbody)
        {
            _inputProfile = inputProfile;
            _propertyCollection = propertyCollection;
            _rigidbody = rigidbody;
        }

        public bool Handle(IList<InputEvent> inputEvents)
        {
            (Vector3 moveVector, PlayerDirections directions) = MoveInputUtils.FromInput(_inputProfile, inputEvents);
            _rigidbody.position += moveVector * (_propertyCollection.Speed * Time.fixedDeltaTime);
            _propertyCollection.Directions = directions;
            return true;
        }
    }
}
