using Implementation.Player.Effect;
using Implementation.Player.Inventory;
using UnityEngine;

namespace Implementation.Player
{
    public class PlayerComponent : MonoBehaviour
    {
        [field: SerializeField]
        public PlayerPropertyCollection PropertyCollection { get; private set; }

        [field: SerializeField]
        public IPlayerStatusEffectCollection StatusEffectCollection { get; private set; }

        [field: SerializeField]
        public PlayerMoveHandler MoveHandler { get; private set; }

        [field: SerializeField]
        public PlayerInventoryComponent InventoryComponent { get; private set; }

        private void Awake()
        {
            PropertyCollection = GetComponent<PlayerPropertyCollection>();
            StatusEffectCollection = GetComponent<PlayerStatusEffectCollection>();
            MoveHandler = GetComponent<PlayerMoveHandler>();
            InventoryComponent = GetComponent<PlayerInventoryComponent>();
        }
    }
}
