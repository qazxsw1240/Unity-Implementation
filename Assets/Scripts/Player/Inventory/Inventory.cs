using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Implementation.Entity;

namespace Implementation.Player.Inventory
{
    public class Inventory : List<IEntity>, IInventory
    {
        public T Get<T>(int index) where T : IEntity
        {
            return (T)this[index];
        }

        public bool TryGet<T>(int index, [MaybeNullWhen(false)] out T entity) where T : IEntity
        {
            if (index < 0 || index >= Count)
            {
                entity = default;
                return false;
            }
            entity = (T)this[index];
            return true;
        }
    }
}
