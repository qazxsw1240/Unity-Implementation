namespace Implementation.Entity
{
    public interface IEntity
    {
        public string Id { get; }

        public string Name { get; }

        public IEntity Clone();
    }
}
