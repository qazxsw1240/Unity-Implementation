using Implementation.Inputs;
using UnityEngine;

namespace Implementation.Player.Effect
{
    public class KnockBackEffect : MonoBehaviour, IPlayerStatusEffect
    {
        [SerializeField]
        private float knockBackAmount = 2f;
        [SerializeField]
        private float knockBackCooldown = 2f;
        [SerializeField]
        private float timeout = 10f;

        private Rigidbody _rigidbody;
        private PlayerPropertyCollection _propertyCollection;
        private PlayerStatusEffectCollection _statusEffectCollection;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _propertyCollection = GetComponent<PlayerPropertyCollection>();
            _statusEffectCollection = GetComponent<PlayerStatusEffectCollection>();
        }

        private void Start()
        {
            Destroy(this, timeout);
            InvokeRepeating(nameof(KnockBack), knockBackCooldown, knockBackCooldown);
            Debug.Log("Knock back activated.");
        }

        private void OnDestroy()
        {
            _statusEffectCollection.RemovePlayerStatusEffect(this);
            Debug.Log("Knock back deactivated.");
        }

        private void KnockBack()
        {
            Vector3 knockBackVector = knockBackAmount * MoveInputUtils.FromPlayerDirection(_propertyCollection.Directions);
            _rigidbody.position -= knockBackVector;
            Debug.Log("Player got knock back.");
        }
    }
}
