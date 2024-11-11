using System;
using System.Collections.Generic;
using UnityEngine;

namespace Implementation.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class MouseInputEventHandler : MonoBehaviour, IMouseEventHandlerCollection
    {
        private readonly List<IMouseEventHandler> _handlers = new List<IMouseEventHandler>();

        private Rigidbody _rigidBody;
        private Collider _collider;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        private void Start()
        {
            if (!Input.mousePresent)
            {
                throw new InvalidProgramException("Cannot detect any mouse devices.");
            }
            MouseInputMoveHandler eventHandler = gameObject.AddComponent<MouseInputMoveHandler>();
            AddHandler(eventHandler);
        }

        private void FixedUpdate()
        {
            MouseButtons buttons = MouseButtons.None;
            if (Input.GetMouseButtonDown(0))
            {
                buttons |= MouseButtons.Left;
            }
            if (Input.GetMouseButtonDown(1))
            {
                buttons |= MouseButtons.Right;
            }
            if (buttons != MouseButtons.None)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    // collider check
                    Collider target = hit.collider;
                    MouseEvent mouseEvent = new MouseEvent(gameObject, transform.position, target.gameObject, hit.point);
                    foreach (IMouseEventHandler handler in _handlers)
                    {
                        handler.OnMouseClick(buttons, mouseEvent);
                    }
                }
            }
        }

        public void AddHandler(IMouseEventHandler handler)
        {
            _handlers.Add(handler);
        }

        public void RemoveHandler(IMouseEventHandler handler)
        {
            _handlers.Add(handler);
        }
    }
}
