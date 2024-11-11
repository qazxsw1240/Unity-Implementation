using UnityEngine;

namespace Implementation.Player
{
    public class PlayerPropertyCollection : MonoBehaviour
    {
        [field: SerializeField]
        public float Speed { get; set; }

        [field: SerializeField]
        public float DashSpeed { get; set; }

        [field: SerializeField]
        public PlayerDirections Directions { get; set; }
    }
}
