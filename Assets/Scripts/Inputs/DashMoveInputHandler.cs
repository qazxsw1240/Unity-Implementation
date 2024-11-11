using System.Collections.Generic;
using System.Linq;
using Implementation.Player;
using UnityEngine;

namespace Implementation.Inputs
{
    public class DashMoveInputHandler : IInputActionHandler
    {
        private readonly InputProfile _inputProfile;
        private readonly PlayerPropertyCollection _propertyCollection;
        private readonly Rigidbody _rigidbody;

        public DashMoveInputHandler(
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
            if (inputEvents.All(inputEvent => inputEvent.KeyCode != KeyCode.LeftControl))
            {
                return false;
            }
            (Vector3 moveVector, PlayerDirections directions) = MoveInputUtils.FromInput(_inputProfile, inputEvents);
            _rigidbody.position += moveVector * (_propertyCollection.DashSpeed * Time.fixedDeltaTime);
            _propertyCollection.Directions = directions;
            return true;
        }
    }
}
