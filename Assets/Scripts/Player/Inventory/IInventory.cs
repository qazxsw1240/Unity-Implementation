using System.Collections.Generic;
using Implementation.Entity;

namespace Implementation.Player.Inventory
{
    public interface IInventory : IList<IEntity>
    {
        public T Get<T>(int index) where T : IEntity;

        public bool TryGet<T>(int index, out T entity) where T : IEntity;
    }
}
