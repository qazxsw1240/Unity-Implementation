using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Implementation.Inputs;
using UnityEngine;

namespace Implementation.Player
{
    public class PlayerMoveHandler : MonoBehaviour, IInputActionHandlerCollection
    {
        [field: SerializeField]
        public InputProfile InputProfile { get; private set; }

        private List<IInputActionHandler> _inputActionHandlers;
        private Rigidbody _rigidbody;
        private KeyCodeInputPool _keyCodeInputPool;
        private PlayerPropertyCollection _propertyCollection;

        private void Awake()
        {
            if (InputProfile == null)
            {
                throw new NullReferenceException("Input profile is not provided.");
            }
            if (!InputProfile.Valid)
            {
                throw new ArgumentException("Input profile is not valid.");
            }
            _rigidbody = GetComponent<Rigidbody>();
            _propertyCollection = GetComponent<PlayerPropertyCollection>();
            if (_rigidbody == null)
            {
                throw new NullReferenceException("Rigidbody is not provided.");
            }
            if (_propertyCollection == null)
            {
                throw new NullReferenceException("Player property collection is not provided.");
            }
            _inputActionHandlers = new List<IInputActionHandler>();
            _keyCodeInputPool = new KeyCodeInputPool();
        }

        private void Start()
        {
            AddAction(new DashMoveInputHandler(InputProfile, _propertyCollection, _rigidbody));
            AddAction(new DefaultMoveInputHandler(InputProfile, _propertyCollection, _rigidbody));
        }

        private void Update()
        {
            _keyCodeInputPool.Update();
        }

        private void FixedUpdate()
        {
            if (_keyCodeInputPool.Count == 0)
            {
                return;
            }
            foreach (IInputActionHandler handler in _inputActionHandlers)
            {
                if (handler.Handle(_keyCodeInputPool))
                {
                    return;
                }
            }
        }

        public void AddAction(IInputActionHandler handler)
        {
            _inputActionHandlers.Add(handler);
        }

        public void RemoveAction(IInputActionHandler handler)
        {
            _inputActionHandlers.Remove(handler);
        }

        private class KeyCodeInputPool : IList<InputEvent>
        {
            public static readonly KeyCode[] KeyCodes = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().ToArray();

            private readonly InputEvent[] _inputEvents;
            private int _position;

            public KeyCodeInputPool()
            {
                _inputEvents = new InputEvent[KeyCodes.Length];
                _position = 0;
            }

            public int Count
            {
                get
                {
                    return _position;
                }
            }

            public bool IsReadOnly => false;

            public InputEvent this[int index]
            {
                get
                {
                    return _inputEvents[index];
                }
                set
                {
                    throw new NotImplementedException();
                }
            }


            public int IndexOf(InputEvent item)
            {
                for (int i = 0; i < _position; i++)
                {
                    if (_inputEvents[i] == item)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void Insert(int index, InputEvent item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public void Add(InputEvent item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(InputEvent item)
            {
                return IndexOf(item) >= 0;
            }

            public void CopyTo(InputEvent[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(InputEvent item)
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                _position = 0;
                for (int i = 0; i < KeyCodes.Length; i++)
                {
                    KeyCode keyCode = (KeyCode)i;
                    if (Input.GetKey(keyCode))
                    {
                        _inputEvents[_position] = new InputEvent(keyCode, InputActions.None);
                        _position++;
                    }
                }
            }
            public IEnumerator<InputEvent> GetEnumerator()
            {
                for (int i = 0; i < _position; i++)
                {
                    yield return _inputEvents[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
