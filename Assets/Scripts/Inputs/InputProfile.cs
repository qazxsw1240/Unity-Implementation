using UnityEngine;

namespace Implementation.Inputs
{
    [CreateAssetMenu(fileName = "InputProfile", menuName = "Scriptable Objects/InputProfile")]
    public class InputProfile : ScriptableObject
    {
        [field: SerializeField]
        public KeyCode ForwardKey { get; private set; }

        [field: SerializeField]
        public KeyCode BackwardKey { get; private set; }

        [field: SerializeField]
        public KeyCode LeftKey { get; private set; }

        [field: SerializeField]
        public KeyCode RightKey { get; private set; }

        public bool Valid
        {
            get
            {
                return ForwardKey != KeyCode.None
                    && BackwardKey != KeyCode.None
                    && LeftKey != KeyCode.None
                    && RightKey != KeyCode.None;
            }
        }

        public bool Contains(KeyCode key)
        {
            return key == ForwardKey || key == BackwardKey || key == LeftKey || key == RightKey;
        }
    }
}
