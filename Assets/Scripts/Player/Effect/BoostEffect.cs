using UnityEngine;

namespace Implementation.Player.Effect
{
    public class BoostEffect : MonoBehaviour, IPlayerStatusEffect
    {
        [SerializeField]
        private float increment = 2f;
        [SerializeField]
        private float timeout = 10f;

        private PlayerPropertyCollection _propertyCollection;
        private PlayerStatusEffectCollection _statusEffectCollection;

        private void Awake()
        {
            _propertyCollection = GetComponent<PlayerPropertyCollection>();
            _statusEffectCollection = GetComponent<PlayerStatusEffectCollection>();
        }

        private void Start()
        {
            _propertyCollection.Speed *= increment;
            _propertyCollection.DashSpeed *= increment;
            Destroy(this, timeout);
            Debug.Log("Boost activated.");
        }

        private void OnDestroy()
        {
            _propertyCollection.Speed /= increment;
            _propertyCollection.DashSpeed /= increment;
            _statusEffectCollection.RemovePlayerStatusEffect(this);
            Debug.Log("Boost deactivated.");
        }
    }
}
