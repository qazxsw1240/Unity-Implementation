using Implementation.Player;
using UnityEngine;

namespace Implementation
{
    public class InventoryDebug : MonoBehaviour
    {
        private PlayerComponent _player;

        public GUIStyle GUIStyle { get; set; }

        private void Awake()
        {
            _player = FindAnyObjectByType<PlayerComponent>();
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(400, 160, 400, 50), "Item number of Inventory: " + _player.InventoryComponent.Inventory.Count);
        }
    }
}
