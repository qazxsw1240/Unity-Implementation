using System;
using UnityEngine;

namespace Implementation.Inputs
{
    public readonly struct InputEvent
    {
        public InputEvent(KeyCode keyCode, InputActions action)
        {
            KeyCode = keyCode;
            Action = action;
        }

        public KeyCode KeyCode { get; }

        public InputActions Action { get; }

        public override bool Equals(object obj)
        {
            if (obj is not InputEvent inputEvent)
            {
                return false;
            }
            return this == inputEvent;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KeyCode, Action);
        }

        public static bool operator ==(InputEvent x, InputEvent y)
        {
            return !(x != y);
        }

        public static bool operator !=(InputEvent x, InputEvent y)
        {
            return x.KeyCode != y.KeyCode || x.Action != y.Action;
        }
    }
}
