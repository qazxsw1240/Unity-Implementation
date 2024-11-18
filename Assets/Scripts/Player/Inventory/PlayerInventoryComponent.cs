using UnityEngine;

namespace Implementation.Player.Inventory
{
    public class PlayerInventoryComponent : MonoBehaviour
    {
        private readonly Inventory _inventory = new Inventory();

        public Inventory Inventory => _inventory;
    }
}
