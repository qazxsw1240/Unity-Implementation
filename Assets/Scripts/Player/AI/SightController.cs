using UnityEngine;
using UnityEngine.Events;

namespace Implementation.Player.AI
{
    public class SightController : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<Collider> OnCollisionEnterEvents { get; private set; }

        [field: SerializeField]
        public UnityEvent<Collider> OnCollisionExitEvents { get; private set; }

        private void OnTriggerEnter(Collider collision)
        {
            OnCollisionEnterEvents.Invoke(collision);
        }

        private void OnTriggerExit(Collider collision)
        {
            OnCollisionExitEvents.Invoke(collision);
        }
    }
}
